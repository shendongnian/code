     private void worker_DoWork(object sender, DoWorkEventArgs e)
     {
        Helpers.RunInUIThread(()=>
       {
         for (long i = 0; i < 1000; i++)
         {
            searchResults.Add(new SearchResult()
            {
                Formatted = SearchResult.FormatString("a*b*c"),
                Raw = "abc"
            });
         }
       }
    }
