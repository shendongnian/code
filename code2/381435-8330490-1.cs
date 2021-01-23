    using System;
    using System.IO;
    using System.Xml;
    
    public class t
    {
    
    	static public string EncodeTo64(string toEncode) {
    		byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
    		string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
    		return returnValue;
    	}
    
    	static public string DecodeFrom64(string encodedData) {
    		byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
    		string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
    		return returnValue;
    	}
    
    	public static void Main() {
    		try {
        	//Create the XmlDocument.
        	XmlDocument doc = new XmlDocument();
    			doc.LoadXml( @"
    			<ReturnValue>
       			<ErrorNumber>0</ErrorNumber>
       			<Message>my message</Message>
    			</ReturnValue>
    			");
    
    			XmlNode nodeMessage = doc.SelectSingleNode( "/ReturnValue/Message" );
    			if( nodeMessage != null ) {
        		XmlDocument docImport = new XmlDocument();
    				docImport.Load( "docwithnamespace.xml" );
    
    				// create a wrapper element for the file, then import and append it after <Message>
    				XmlElement nodeWrapper = (XmlElement)doc.CreateElement( "wrapper" );
    				nodeWrapper.SetAttribute( "type", "bin.base64" );
    
    				nodeWrapper = (XmlElement)doc.ImportNode( nodeWrapper, true );
    				XmlNode ndImport = nodeMessage.ParentNode.AppendChild( nodeWrapper.CloneNode( true ) );
    				ndImport.InnerText = EncodeTo64( docImport.OuterXml );
    				doc.Save( "wrapperadded.xml" );
    
    				// Next, let's test un-doing the wrapping
    				// Re-load the "wrapped" document
    				XmlDocument docSaved = new XmlDocument();
    				docSaved.Load( "wrapperadded.xml" );
    
    				// Get the wrapped element, decode from base64 write to disk
    				XmlNode node = doc.SelectSingleNode( "/ReturnValue/wrapper" );
    				if( node != null ) {
    					// Load the content, and save as a new XML
    					XmlDocument docUnwrapped = new XmlDocument();
    					docUnwrapped.LoadXml( DecodeFrom64( node.InnerText ) );
    					docUnwrapped.Save( "unwrapped.xml" );
    					Console.WriteLine( "Eureka" );
    				}
    			}
    
    
    		} catch( Exception e ) {
    			Console.WriteLine(e.Message);
    		}
    	}
    }
