    private string CheckMail() {
            string result = "0";
    
            try {
                var url = @"https://gmail.google.com/gmail/feed/atom";
                var USER = "username";
                var PASS = "password";
    
                var encoded = TextToBase64( USER + ":" + PASS );
    
                var myWebRequest = HttpWebRequest.Create( url );
                myWebRequest.Method = "POST";
                myWebRequest.ContentLength = 0;
                myWebRequest.Headers.Add( "Authorization", "Basic " + encoded );
    
                var response = myWebRequest.GetResponse();
                var stream = response.GetResponseStream();
    
                XmlReader reader = XmlReader.Create( stream );
                while ( reader.Read() )
                    if ( reader.NodeType == XmlNodeType.Element )
                        if ( reader.Name == "fullcount" ) {
                            result = reader.ReadElementContentAsString();
                            return result;
                        }
            } catch ( Exception ee ) { Console.WriteLine( ee.Message ); }
            return result;
        }
