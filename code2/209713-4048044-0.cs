    using System; 
    using System.IO; 
    using System.Net; 
    using System.Text; 
    
    ... 
    
        public static void GetFile 
                ( 
                string strURL, 
                string strFilePath 
                ) 
            { 
    
                WebRequest myWebRequest = WebRequest.Create(strURL);  
    
                WebResponse myWebResponse = myWebRequest.GetResponse();  
    
                Stream ReceiveStream = myWebResponse.GetResponseStream(); 
                    
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8"); 
    
                StreamReader readStream = new StreamReader( ReceiveStream, encode ); 
    
                string strResponse=readStream.ReadToEnd(); 
                     
                StreamWriter oSw=new StreamWriter(strFilePath); 
         
                oSw.WriteLine(strResponse); 
    
                oSw.Close(); 
    
                readStream.Close(); 
             
                myWebResponse.Close(); 
    
            } 
