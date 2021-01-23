    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        public override void ProcessRequest(HttpContext context)
        {
            int bytesProcessed = 0;
            Stream remoteStream = null;
            Stream localStream = null;
            context.Response.ContentType = "application/octet-stream";
    
            WebRequest request = WebRequest.Create("http://widgets.twimg.com/j/2/widget.js");
        //    request.Method = "GET";
            request.ContentType = "application/octet-stream";
    
            using (WebResponse response = request.GetResponse())
            {
    
                using (Stream requestStream = response.GetResponseStream())
                {
                    localStream = File.Create(@"c:\1.y2yy");
    
                    // Allocate a 1k buffer
                    byte[] buffer = new byte[1024];
                    int bytesRead;
    
                    // Simple do/while loop to read from stream until
                    // no bytes are returned
                    do
                    {
                        // Read data (up to 1k) from the stream
                        bytesRead = requestStream.Read(buffer, 0, buffer.Length);
    
                        // Write the data to the local file
                        localStream.Write(buffer, 0, bytesRead);
    
                        // Increment total bytes processed
                        bytesProcessed += bytesRead;
                    } while (bytesRead > 0);
                    localStream.Close();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    }
