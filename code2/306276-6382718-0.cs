     private void Callback(IAsyncResult asyncResult)
     {
         try 
         {
             HttpWebResponse resp =  (HttpWebResponse)myRequest.EndGetResponse(asyncResult);
         }
         catch (Exception e)
         {
             //Something bad happened during the request
         }
     }
