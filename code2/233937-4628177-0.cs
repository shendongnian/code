    using (Browser browser = new IE("http://www.sp4ce.net/computer/2011/01/06/how-to-use-WatiN-with-NUnit.en.html"))
    {
       Image image = browser.Images[0];
       Console.Write(image.Uri);
    
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(image.Uri);
       WebResponse response = request.GetResponse();
       using (Stream stream = response.GetResponseStream())
       using (FileStream fs = File.OpenWrite(@"c:\foo.png"))
       {
          byte[] bytes = new byte[1024];
          int count;
          while((count = stream.Read(bytes, 0, bytes.Length))!=0)
          {
             fs.Write(bytes, 0, count);
          }
       }
    }
