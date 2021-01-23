     try
     {
          HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create("http://www.example.com/image.jpg");
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          exist = response.StatusCode == HttpStatusCode.OK;
     }
     catch
     {
          exist = false;
     }
