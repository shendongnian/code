     public IEnumerable<string> Get()
     {
         BLL.todManager tm = new BLL.todManager();
         Models.TodViewModel tvm = new Models.TodViewModel();
    
         tvm.ModelGetTod = tm.Gettods().ToArray();
         return tvm.ModelGetTod as IEnumerable<string>;
     }
