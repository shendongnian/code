    TaskData data = new TaskData((percentage)=> Console.WriteLine(percentage + "% completed"));
    
                Task myTask = new Task(new Action<object>((para)=>
                {
                    ((TaskData)para).TriggerCallBack(4);
                }
    
                ),data);
    
                myTask.Start();
    
                Console.ReadLine();
