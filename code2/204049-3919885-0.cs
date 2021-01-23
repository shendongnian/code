    var r = httpWebRequest.GetResponse();
    if(r.StatusCode != 200)
    {
        MessageBox.Show(r.Content); // Display the error 
    }
    else
    {
        var streamIn = new StreamReader(r.GetResponseStream());
        string strResponse = streamIn.ReadToEnd();
        streamIn.Close();
        return strResponse;
    }
