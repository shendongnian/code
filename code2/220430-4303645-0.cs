    Task<int>[] taskArray = new Task<double>[]
       {
           Task<int>.Factory.StartNew(() => SmallMethodA()),
           Task.Factory.StartNew(() => SmallMethodB()),           
       };
    
    int result = 0;
    for (int i = 0; i < taskArray.Length; i++)
        result += taskArray[i].Result;
