    Task<double>[] taskArray = new Task<double>[]
       {
           Task<double>.Factory.StartNew(() => DoComputation1()),
    
           // May be written more conveniently like this:
           Task.Factory.StartNew(() => DoComputation2()),
           Task.Factory.StartNew(() => DoComputation3())                
       };
    
    double[] results = new double[taskArray.Length];
    for (int i = 0; i < taskArray.Length; i++)
        results[i] = taskArray[i].Result;
