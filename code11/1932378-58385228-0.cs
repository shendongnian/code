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
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace Conversive.PHPSerializationLibrary {
    /// <summary>
    /// Serializer Class.
    /// </summary>
    public class PhpSerializer {
        //types:
        // N = null
        // s = string
        // i = int
        // d = double
        // a = array (hashtable)
        private readonly NumberFormatInfo _nfi;
        public Encoding StringEncoding = new UTF8Encoding();
        public bool XmlSafe = true;
        //This member tells the serializer wether or not to strip carriage returns from strings when serializing and adding them back in when deserializing
        private int _pos; //for unserialize
        private Dictionary<List<object>, bool> _seenArrayLists; //for serialize (to infinte prevent loops) lol
        private Dictionary<Dictionary<object, object>, bool> _seenHashtables; //for serialize (to infinte prevent loops)
        public PhpSerializer() {
            _nfi = new NumberFormatInfo { NumberGroupSeparator = "", NumberDecimalSeparator = "." };
        }
        public string Serialize(object obj) {
            _seenArrayLists = new Dictionary<List<object>, bool>();
            _seenHashtables = new Dictionary<Dictionary<object, object>, bool>();
            return serialize(obj, new StringBuilder()).ToString();
        }
        //Serialize(object obj)
        private StringBuilder serialize(object obj, StringBuilder sb) {
            if (obj == null) return sb.Append("N;");
            if (obj is string) {
                var str = (string)obj;
                if (XmlSafe) {
                    str = str.Replace("rn", "n"); //replace rn with n
                    str = str.Replace("r", "n"); //replace r not followed by n with a single n  Should we do this?
                }
                return sb.Append("s:" + StringEncoding.GetByteCount(str) + ":"" + str + "";");
            }
            if (obj is bool) return sb.Append("b:" + (((bool)obj) ? "1" : "0") + ";");
            if (obj is int) {
                var i = (int)obj;
                return sb.Append("i:" + i.ToString(_nfi) + ";");
            }
            if (obj is double) {
                var d = (double)obj;
                return sb.Append("d:" + d.ToString(_nfi) + ";");
            }
            if (obj is List<object>) {
                if (_seenArrayLists.ContainsKey((List<object>)obj))
                    return sb.Append("N;"); //cycle detected
                _seenArrayLists.Add((List<object>)obj, true);
                var a = (List<object>)obj;
                sb.Append("a:" + a.Count + ":{");
                for (int i = 0; i < a.Count; i++) {
                    serialize(i, sb);
                    serialize(a[i], sb);
                }
                sb.Append("}");
                return sb;
            }
            if (obj is Dictionary<object, object>) {
                if (_seenHashtables.ContainsKey((Dictionary<object, object>)obj))
                    return sb.Append("N;");
                _seenHashtables.Add((Dictionary<object, object>)obj, true);
                var a = (Dictionary<object, object>)obj;
                sb.Append("a:" + a.Count + ":{");
                foreach (var entry in a) {
                    serialize(entry.Key, sb);
                    serialize(entry.Value, sb);
                }
                sb.Append("}");
                return sb;
            }
            return sb;
        }
        public object Deserialize(string str) {
            _pos = 0;
            return deserialize(str);
        }
        private object deserialize(string str) {
            if (str == null || str.Length <= _pos)
                return new Object();
            int start, end, length;
            string stLen;
            switch (str[_pos]) {
                case 'N':
                    _pos += 2;
                    return null;
                case 'b':
                    char chBool = str[_pos + 2];
                    _pos += 4;
                    return chBool == '1';
                case 'i':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(";", start);
                    var stInt = str.Substring(start, end - start);
                    _pos += 3 + stInt.Length;
                    return Int32.Parse(stInt, _nfi);
                case 'd':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(";", start);
                    var stDouble = str.Substring(start, end - start);
                    _pos += 3 + stDouble.Length;
                    return Double.Parse(stDouble, _nfi);
                case 's':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    var bytelen = Int32.Parse(stLen);
                    length = bytelen;
                    if ((end + 2 + length) >= str.Length) length = str.Length - 2 - end;
                    var stRet = str.Substring(end + 2, length);
                    while (StringEncoding.GetByteCount(stRet) > bytelen) {
                        length--;
                        stRet = str.Substring(end + 2, length);
                    }
                    _pos += 6 + stLen.Length + length;
                    if (XmlSafe) stRet = stRet.Replace("n", "rn");
                    return stRet;
                case 'a':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    length = Int32.Parse(stLen);
                    var htRet = new Dictionary<object, object>(length);
                    var alRet = new List<object>(length);
                    _pos += 4 + stLen.Length; //a:Len:{
                    for (int i = 0; i < length; i++) {
                        var key = deserialize(str);
                        var val = deserialize(str);
                        if (alRet != null) {
                            if (key is int && (int)key == alRet.Count)
                                alRet.Add(val);
                            else
                                alRet = null;
                        }
                        htRet[key] = val;
                    }
                    _pos++;
                    if (_pos < str.Length && str[_pos] == ';')
                        _pos++;
                    return alRet != null ? (object)alRet : htRet;
                default:
                    return "";
            }
        }
    }
}
  [1]: http://csphpserial.sourceforge.net/
