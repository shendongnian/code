    static public void cancelAllCoroutines()
       {
           foreach (bool request in cancellationRequests)
           {
               request = true;
           }
       }
