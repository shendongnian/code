/*
 * Serializer.cs
 * This is the Serializer class for the PHPSerializationLibrary
 * 
 * https://sourceforge.net/projects/csphpserial/
 *  
 * Copyright 2004 Conversive, Inc. Licensed under Common Public License 1.0
 * 
 * Modified for WP7-Silverlight by Gordon Breuer
 * https://gordon-breuer.de/unknown/2011/05/04/php-un-serialize-with-c.html
 *
 * Updated to be thread-safe and correctly reentrant and with C# 7.0 features added for https://stackoverflow.com/questions/58384540/c-sharp-string-with-from-database-cannot-do-interpolation/
 * 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace Conversive.PHPSerializationLibrary {
    
   
	public class PhpSerializer
	{
	
		//types:
		// N = null
		// s = string
		// i = int
		// d = double
		// a = array (hashtable)
	
		private static readonly NumberFormatInfo _nfi = new NumberFormatInfo { NumberGroupSeparator = "", NumberDecimalSeparator = "." };
		
		public Encoding StringEncoding { get; }
	
		/// <summary>Whether or not to strip carriage returns from strings when serializing and adding them back in when deserializing</summary>
		public Boolean XmlSafe { get; }
	
		public PhpSerializer()
			: this( encoding: new UTF8Encoding(), xmlSafe: true )
		{
		}
	
		public PhpSerializer( Encoding encoding, Boolean xmlSafe )
		{
			this.StringEncoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
			this.XmlSafe        = xmlSafe;
		}
	
		private class SerializeState
		{
			public readonly StringBuilder sb = new StringBuilder();
			
			// These collections used for cycle-detection.
			public readonly HashSet<Object> seenCollections = new HashSet<Object>();
		}
	
		public String Serialize(object obj)
		{
			SerializeState state = new SerializeState();
			
			this.Serialize(obj, state );
			
			return state.sb.ToString();
		}
	
		//Serialize(object obj)
	
		private void Serialize( Object obj, SerializeState state )
		{
			StringBuilder sb = state.sb;
	
			if (obj == null)
			{
				sb.Append("N;");
			}
			else if (obj is string str)
			{
				if (XmlSafe)
				{
					str = str.Replace("rn", "n"); //replace rn with n
					str = str.Replace("r", "n"); //replace r not followed by n with a single n  Should we do this?
				}
				sb.Append("s:" + StringEncoding.GetByteCount(str) + ":" + str + ";");
			}
			else if (obj is bool b)
			{
				sb.Append("b:" + ( b ? "1" : "0") + ";");		
			}
			else if (obj is int objInt)
			{
				sb.Append("i:" + objInt.ToString(_nfi) + ";");
			}
			else if (obj is double objDbl)
			{
				sb.Append("d:" + objDbl.ToString(_nfi) + ";");
			}
			else if ( (obj is IReadOnlyDictionary<object, object> ) || ( obj is IDictionary<object, object> ) )
			{
				if (state.seenCollections.Contains(obj))
				{
					sb.Append("N;");
				}
				else
				{
					state.seenCollections.Add(obj);
	
					IEnumerable<KeyValuePair<Object,Object>> asDictEnum = (IEnumerable<KeyValuePair<Object,Object>>)obj;
	
					sb.Append("a:" + asDictEnum.Count() + ":{");
					foreach (var entry in asDictEnum)
					{
						this.Serialize(entry.Key, state);
						this.Serialize(entry.Value, state);
					}
					sb.Append("}");
				}
			}
			else if (obj is IEnumerable<object> enumerable)
			{
				if (state.seenCollections.Contains( enumerable ) )
				{
					sb.Append("N;");
				}
				else
				{
					state.seenCollections.Add(enumerable);
	 
					IReadOnlyList<Object> asList = enumerable as IReadOnlyList<Object>; // T[] / Array<T> implements IReadOnlyList<T> already.
					if( asList == null ) asList = enumerable.ToList();
	
					sb.Append("a:" + asList.Count + ":{");
					
					Int32 i = 0;
					foreach( Object item in asList )
					{
						this.Serialize(i, state);
						this.Serialize( item, state);
	
						i++;
					}
					
					sb.Append("}");
				}
			}
			else
			{
				throw new SerializationException( "Value could not be serialized." );
			}
		}
	
		public Object Deserialize(String str)
		{
			Int32 pos = 0;
			return this.Deserialize(str, ref pos ); 
		}
	
		private Object Deserialize( String str, ref Int32 pos )
		{
			if( String.IsNullOrWhiteSpace( str ) )
				return new Object();
				
			int start, end, length;
			string stLen;
			switch( str[pos] )
			{
			case 'N':
				pos += 2;
				return null;
			case 'b':
				char chBool = str[pos + 2];
				pos += 4;
				return chBool == '1';
			case 'i':
				start = str.IndexOf(":", pos) + 1;
				end = str.IndexOf(";", start);
				var stInt = str.Substring(start, end - start);
				pos += 3 + stInt.Length;
				return Int32.Parse(stInt, _nfi);
			case 'd':
				start = str.IndexOf(":", pos) + 1;
				end = str.IndexOf(";", start);
				var stDouble = str.Substring(start, end - start);
				pos += 3 + stDouble.Length;
				return Double.Parse(stDouble, _nfi);
			case 's':
				start = str.IndexOf(":", pos) + 1;
				end = str.IndexOf(":", start);
				stLen = str.Substring(start, end - start);
				var bytelen = Int32.Parse(stLen);
				length = bytelen;
				if ((end + 2 + length) >= str.Length) length = str.Length - 2 - end;
				var stRet = str.Substring(end + 2, length);
				while (StringEncoding.GetByteCount(stRet) > bytelen)
				{
					length--;
					stRet = str.Substring(end + 2, length);
				}
				pos += 6 + stLen.Length + length;
				if (XmlSafe) stRet = stRet.Replace("n", "rn");
				return stRet;
			case 'a':
				start = str.IndexOf(":", pos) + 1;
				end = str.IndexOf(":", start);
				stLen = str.Substring(start, end - start);
				length = Int32.Parse(stLen);
				var htRet = new Dictionary<object, object>(length);
				var alRet = new List<object>(length);
				pos += 4 + stLen.Length; //a:Len:{
				for (int i = 0; i < length; i++)
				{
					var key = this.Deserialize(str, ref pos);
					var val = this.Deserialize(str, ref pos);
	
					if (alRet != null)
					{
						if (key is int && (int)key == alRet.Count)
							alRet.Add(val);
						else
							alRet = null;
					}
					htRet[key] = val;
				}
				pos++;
				if( pos < str.Length && str[pos] == ';')
				{
					pos++;
				}
					
				return alRet != null ? (object)alRet : htRet;
			default:
				return "";
			}
		}
	}
}
When I run this in Linqpad with your input I get this result output:
void Main()
{
	const String attribs = @"a:3:{s:9:""variation"";a:6:{s:4:""name"";s:9:""Variation"";s:5:""value"";s:24:""type a | type b | type c"";s:8:""position"";s:1:""0"";s:10:""is_visible"";s:1:""1"";s:12:""is_variation"";s:1:""1"";s:11:""is_taxonomy"";s:1:""0"";}s:5:""color"";a:6:{s:4:""name"";s:5:""Color"";s:5:""value"";s:27:""RED | BLUE | WHITE | ORANGE"";s:8:""position"";s:1:""1"";s:10:""is_visible"";s:1:""1"";s:12:""is_variation"";s:1:""1"";s:11:""is_taxonomy"";s:1:""0"";}s:4:""test"";a:6:{s:4:""name"";s:4:""TEST"";s:5:""value"";s:15:""120 | 140 | 160"";s:8:""position"";s:1:""2"";s:10:""is_visible"";s:1:""1"";s:12:""is_variation"";s:1:""0"";s:11:""is_taxonomy"";s:1:""0"";}}";
	
	PhpSerializer s = new PhpSerializer();
	Object result = s.Deserialize( attribs ); 
	result.Dump();
}
Visualized output:
[![enter image description here][2]][2]
  [1]: http://csphpserial.sourceforge.net/
  [2]: https://i.stack.imgur.com/8eDLe.png
