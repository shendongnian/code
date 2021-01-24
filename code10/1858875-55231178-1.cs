    private async void button_test_Click(object sender, EventArgs e)
    {
         var tasks = new List<Task<string>>();
         for (int n = 0; n < 5; n++)  //multiple requests
         {
            tasks.Add(MakeRequestAsync(url));
         }
         await Task.WhenAll(tasks); // wait for all of them to complete;
         foreach(var task in tasks)
         {
             var str = await task; // or task.Result, won't block, already completed;
         }
    }
