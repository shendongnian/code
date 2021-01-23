    public ActionResult Index()
        {
            MyDataContext dc = new MyDataContext();
    
            IQueryable<Table1Data> j =
                from n in dc.Table1                     
                select n;
    
            IQueryable<Table2Data> l =
                from k in dc.Table2        
                select k;
             YourModelName model = new  YourModelName(j, l);
    
            return View(model);
        }
