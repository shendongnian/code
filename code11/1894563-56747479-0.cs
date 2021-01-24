    public ActionResult OnGet()
    {
         if (NTUser.Role != Role.Admin)
         {
            return RedirectToPage("/Denied");
         }
         else
         {
            return RedirectToAction(Matching);
         }
          ...other if with return
    }
        
    public ActionResult Matching()
    {
       //dosomething
    }
