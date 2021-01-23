    using System.IO;
    using System.Xml.Serialization;
    using System;
    
    namespace Serialization01 {
    	class Program {
    		static void Main ( string [] args ) {
    			// Initiate the class
    			TableDisplayFields t = new TableDisplayFields( );
    
    			t.RecordNumberField = "ID";
    			t.FieldName.Add( "NAME" );
    			t.FieldName.Add( "DESCRIPTION" );
    
    			TextWriter tw = new StreamWriter( Path.Combine( Environment.CurrentDirectory, "Data.xml" ) );
    
    			XmlSerializer xs = new XmlSerializer( t.GetType( ) );
    
    			xs.Serialize( tw, t );
    
    			tw.Flush( );
    			tw.Close( );
    
    			TextReader tr = new StreamReader( Path.Combine( Environment.CurrentDirectory, "Data.xml" ) );
    			TableDisplayFields t2 = xs.Deserialize( tr ) as TableDisplayFields;
    
    			Console.WriteLine( "RecordNumberField for t2 is {0}", t2.RecordNumberField );
    			foreach ( string field in t2.FieldName ) {
    				Console.WriteLine( "Found field '{0}'", field );
    			}
    		}
    	}
    }
