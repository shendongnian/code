     HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(imageFilePath);
     request.Timeout = 5000;
     request.ReadWriteTimeout = 20000;
     
     HttpWebResponse response = (HttpWebResponse)request.GetResponse();
     System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
     // Save the response to the output stream
     Response.ContentType = "image/gif";
