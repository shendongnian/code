>Task<int> task1 = new Task<int>(() => { ... ; return sum });<br>
 task1.Start();<br> 
 Task<int> task2 = new Task<int>(() => { ... ; return sum });<br>
 task2.Start();<br>
 task1.Wait() <br> 
 Console.WriteLine("Result 1: {0}", task1.Result);<br>
 task2.Wait() <br>
 Console.WriteLine("Result 2: {0}", task2.Result);
  
