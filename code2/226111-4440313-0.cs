      public YourModel{
        public bool IsAction1Allowed {get;set;}
        }
        
        public ActionResult Index(YourModel model = null){
        
        model = model ?? new Yourmodel();
        
        return View(model)
        }
        
       
     or (use public properties)
  
      public MyController:Controller{
        
        public bool IsAction1Allowed {get;set;}
       public ActionResult Index(){
        
        vare model = Yourmodel();
        model.IsAction1Allow = IsAction1Allowed
        
        return View(model)
        }
        
        
        }
    
    or (use constructor)
    
       public MyController(Settings setting){
        
        
        public ActionResult Index(){
        
        vare model = Yourmodel();
        model.IsAction1Allow = settings.IsAction1Allowed
        
        return View(model)
        }
        
    }
