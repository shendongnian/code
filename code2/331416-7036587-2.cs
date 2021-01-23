    catch (WebException exception)
    {
      string responseText;
      if (exception.Response != null)
      {
        var responseStream = exception.Response.GetResponseStream();
        if (responseStream != null)
        {
          using (var reader = new StreamReader(responseStream))
          {
            responseText = reader.ReadToEnd();
          }
        }
      }
    }
