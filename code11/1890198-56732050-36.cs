    static public void cancelAllCoroutines()
       {
           foreach (bool request in cancelRequests)
           {
               request = true;
           }
       }
