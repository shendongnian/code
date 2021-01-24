    for (int i = 0; i < 1000; i++) {
      ...
      Action newAction2 = new Action(() => { 
        System.Console.WriteLine("Inside Action2 " + i); });
      Task.Run(newAction2);
