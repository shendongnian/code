    public ActionResult Index()
    {
          List<SelectListItem> items = new List<SelectListItem>();
          NumberClass num = new NumberClass();
          for(int i=0;i<20;i++)
          {
              SelectListItem selectList = new SelectListItem()
              {
                  Text = i.ToString(),
                  Value = i.ToString()                 
              };
    
              items.Add(selectList);
          }
          return View(items);
    }
