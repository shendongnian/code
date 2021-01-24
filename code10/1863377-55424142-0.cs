     var tasks = new List<Task>()
     { 
         SomeMethod1Async(arg1, arg2),
         SomeMethod2Async(arg1)
     };
     await Task.WhenAll(tasks.ToArray());
     var result1 = ((Task<Result1>)tasks[0]).Result;
     var result2 = ((Task<Result2>)tasks[1]).Result;
