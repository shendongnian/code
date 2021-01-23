     bool exist = false;
     try
     {
          HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create("http://www.example.com/image.jpg");
          using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
          {
               exist = response.StatusCode == HttpStatusCode.OK;
          }
     }
     catch
     {
     }
