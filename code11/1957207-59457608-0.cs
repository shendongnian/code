    [HttpGet]
    public ViewResult Index()
    {
    
         return View();
    }
    
    [HttpPost]
    public ViewResult Index(Bilgi bilgi)
    {
         // Write Code for Submit
         bilgi=LoadBilgi();
         return View(bilgi);
    }
    
    [NoAction]
    public Bilgi LoadBilgi()
    {
         Bilgi newBilgi= new Bilgi ();
         // Load data and assign to newBilgi
         return newBilgi;
    }
