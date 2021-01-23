    try
    {
        getResult = client.DownloadString(address);
    }
    catch (WebException ex)
    {
        String responseFromServer = ex.Message.ToString() + " ";
        if (ex.Response != null)
        {
            using (WebResponse response = ex.Response)
            {
                Stream dataRs = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(dataRs))
                {
                    responseFromServer += reader.ReadToEnd();
                }
            }
        }
        _log.Error("Server Response: " + responseFromServer);
        MessageBox.Show(responseFromServer);
    }
