    public static void CancelAllCoroutines()
    {
       Debug.Log("cancelling all coroutines with total of : " + cancelTokens.Count);
       foreach (CancellationTokenSource ca in cancelTokens)
       {
           ca.Cancel();
       }
       // Clear the list as @Jack Mariani mentioned
       cancelTokens.Clear();
    }
