    try
    {
        WebRequest request = HttpWebRequest.Create("http://www.microsoft.com/NonExistantFile.aspx");
        request.Method = "HEAD"; // Just get the document headers, not the data.
        request.Credentials = System.Net.CredentialCache.DefaultCredentials;
        // This may throw a WebException:
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // If no exception was thrown until now, the file exists and we 
                // are allowed to read it. 
                MessageBox.Show("The file exists!");
            }
            else
            {
                // Some other HTTP response - probably not good.
                // Check its StatusCode and handle it.
            }
        }
    }
    catch (WebException ex)
    {
        // Cast the WebResponse so we can check the StatusCode property
        HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
 
        // Determine the cause of the exception, was it 404?
        if (webResponse.StatusCode == HttpStatusCode.NotFound)
        {
            MessageBox.Show("The file does not exist!");
        }
        else
        {
            // Handle differently...
            MessageBox.Show(ex.Message);
        }
    }
