    public class Example
    {
       public static void Main()
       {
          Task[] taskArray = new Task[10];
          for (int i = 0; i < taskArray.Length; i++) {
             taskArray[i] = Task.Factory.StartNew( (Object obj ) => {
                                                      CustomData data = obj as CustomData;
                                                      if (data == null) 
                                                         return;
                                         
                                                      data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                                   },
                                                   new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks} );
          }
          Task.WaitAll(taskArray);     
          foreach (var task in taskArray) {
             var data = task.AsyncState as CustomData;
             if (data != null)
                Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                  data.Name, data.CreationTime, data.ThreadNum);
          }                     
       }
    }
