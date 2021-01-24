    foreach (var singleElement in listOfelements)
    {
         Action action = () =>
                   {         
                        var ws = new WCFClient(binding,endpoint);                   
                        var singleResult = ws.Call(singleElement);     
                        ws.Close();                            
                        resultList.Add(singleResult);        
                   };
         tasks.Add(Task.Factory.StartNew(action, TaskCreationOptions.LongRunning));
    }
    
    Task.WaitAll(tasks.ToArray());
    //Do other stuff with the resultList...
