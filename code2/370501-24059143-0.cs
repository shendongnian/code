     private static IDictionary<Guid, int> tasks = new Dictionary<Guid, int>();
 
     public ActionResult Index()
     {
       return View();
     }
 
     public ActionResult Start()
     {
       var taskId = Guid.NewGuid();
       tasks.Add(taskId, 0);
    
       Task.Factory.StartNew(() =>
       {
         for (var i = 0; i <= 100; i++)
         {
           tasks[taskId] = i; // update task progress
           Thread.Sleep(50); // simulate long running operation
         }
         tasks.Remove(taskId);
       });
 
       return Json(taskId);
     }
 
     public ActionResult Progress(Guid id)
     {
       return Json(tasks.Keys.Contains(id) ? tasks[id] : 100);
     }
