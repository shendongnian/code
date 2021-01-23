     try
     {
        q.DeleteMessage(msg);
     }
     catch (StorageClientException ex)
     {
     if (ex.ExtendedErrorInformation.ErrorCode == "MessageNotFound")
     {
         // pop receipt must be invalid
         // ignore or log (so we can tune the visibility timeout)
     }
     else
     {
        // not the error we were expecting
         throw;
     }
    }
