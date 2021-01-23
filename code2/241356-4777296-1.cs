    var request = (HttpWebRequest)WebRequest.Create("http://localhost/Game/Save");
    string data = string.Format("Id={0}&Name={1}", HttpUtility.UrlEncode(game.Id), HttpUtility.UrlEncode(game.Name));
    request.Method = "POST";
    request.ContentLength = data.Length;
    request.contentType= "application/x-www-form-urlencoded";
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
      writer.Write(data);
    }
    // Post the data.
    var response = (HttpWebResponse)request.GetResponse();
