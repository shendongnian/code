        using (WaitHandle handle = asyncResponse.AsyncWaitHandle)
        {
          asyncResponse.AsyncWaitHandle.WaitOne();
          string response = asyncRequest.EndInvoke(asyncResponse);
          asyncResponse.AsyncWaitHandle.Close();
          return response;
        } 
