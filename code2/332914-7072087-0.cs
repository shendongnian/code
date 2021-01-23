    try
    {
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);//WebException if aborted
    }
    catch(WebException e)
    {
      if(e.Status == WebExceptionStatus.RequestCanceled)
        {
          //WORK
        }
    }
          
