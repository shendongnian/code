    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Xml;
    
    namespace XSLTTest.Xml
    {
    	public class XmlStringWriter :
    		XmlWriter
    	{
    		public static XmlStringWriter Create(XmlWriterSettings Settings)
    		{
    			return new XmlStringWriter(Settings);
    		}
    
    		public static XmlStringWriter Create()
    		{
    			return XmlStringWriter.Create(XmlStringWriter.XmlWriterSettings_display);
    		}
    
    		public static XmlWriterSettings XmlWriterSettings_display
    		{
    			get
    			{
    				XmlWriterSettings XWS = new XmlWriterSettings();
    				XWS.OmitXmlDeclaration = false; // make a choice?
    				XWS.NewLineHandling = NewLineHandling.Replace;
    				XWS.NewLineOnAttributes = false;
    				XWS.Indent = true;
    				XWS.IndentChars = "\t";
    				XWS.NewLineChars = Environment.NewLine;
    				//XWS.ConformanceLevel = ConformanceLevel.Fragment;
    				XWS.CloseOutput = false;
    
    				return XWS;
    			}
    		}
    
    		public override string ToString()
    		{
    			return myXMLStringBuilder.ToString();
    		}
    
    		//public static implicit operator XmlWriter(XmlStringWriter Me)
    		//{
    		//   return Me.myXMLWriter;
    		//}
    
    		//--------------
    
    		protected StringBuilder myXMLStringBuilder = null;
    		protected XmlWriter myXMLWriter = null;
    		
    		protected XmlStringWriter(XmlWriterSettings Settings)
    		{
    			myXMLStringBuilder = new StringBuilder();
    			myXMLWriter = XmlWriter.Create(myXMLStringBuilder, Settings);
    		}
    
    		public override void Close()
    		{
    			myXMLWriter.Close();
    		}
    
    		public override void Flush()
    		{
    			myXMLWriter.Flush();
    		}
    
    		public override string LookupPrefix(string ns)
    		{
    			return myXMLWriter.LookupPrefix(ns);
    		}
    
    		public override void WriteBase64(byte[] buffer, int index, int count)
    		{
    			myXMLWriter.WriteBase64(buffer, index, count);
    		}
    
    		public override void WriteCData(string text)
    		{
    			myXMLWriter.WriteCData(text);
    		}
    
    		public override void WriteCharEntity(char ch)
    		{
    			myXMLWriter.WriteCharEntity(ch);
    		}
    
    		public override void WriteChars(char[] buffer, int index, int count)
    		{
    			myXMLWriter.WriteChars(buffer, index, count);
    		}
    
    		public override void WriteComment(string text)
    		{
    			myXMLWriter.WriteComment(text);
    		}
    
    		public override void WriteDocType(string name, string pubid, string sysid, string subset)
    		{
    			myXMLWriter.WriteDocType(name, pubid, sysid, subset);
    		}
    
    		public override void WriteEndAttribute()
    		{
    			myXMLWriter.WriteEndAttribute();
    		}
    
    		public override void WriteEndDocument()
    		{
    			myXMLWriter.WriteEndDocument();
    		}
    
    		public override void WriteEndElement()
    		{
    			myXMLWriter.WriteEndElement();
    		}
    
    		public override void WriteEntityRef(string name)
    		{
    			myXMLWriter.WriteEntityRef(name);
    		}
    
    		public override void WriteFullEndElement()
    		{
    			myXMLWriter.WriteFullEndElement();
    		}
    
    		public override void WriteProcessingInstruction(string name, string text)
    		{
    			myXMLWriter.WriteProcessingInstruction(name, text);
    		}
    
    		public override void WriteRaw(string data)
    		{
    			myXMLWriter.WriteRaw(data);
    		}
    
    		public override void WriteRaw(char[] buffer, int index, int count)
    		{
    			myXMLWriter.WriteRaw(buffer, index, count);
    		}
    
    		public override void WriteStartAttribute(string prefix, string localName, string ns)
    		{
    			myXMLWriter.WriteStartAttribute(prefix, localName, ns);
    		}
    
    		public override void WriteStartDocument(bool standalone)
    		{
    			myXMLWriter.WriteStartDocument(standalone);
    		}
    
    		public override void WriteStartDocument()
    		{
    			myXMLWriter.WriteStartDocument();
    		}
    
    		public override void WriteStartElement(string prefix, string localName, string ns)
    		{
    			myXMLWriter.WriteStartElement(prefix, localName, ns);
    		}
    
    		public override WriteState WriteState
    		{
    			get 
    			{
    				return myXMLWriter.WriteState;
    			}
    		}
    
    		public override void WriteString(string text)
    		{
    			myXMLWriter.WriteString(text);
    		}
    
    		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
    		{
    			myXMLWriter.WriteSurrogateCharEntity(lowChar, highChar);
    		}
    
    		public override void WriteWhitespace(string ws)
    		{
    			myXMLWriter.WriteWhitespace(ws);
    		}
    	}
    }
