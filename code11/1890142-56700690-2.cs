    public static void cancelAllCoroutines()
    {
       Debug.Log("cancelling all coroutines with total of : " + cancelTokens.Count);
       foreach (CancellationTokenSource ca in cancelTokens)
       {
           ca.Cancel();
       }
    }
