    public ActionResult About()
    {
        return View("About","_otherLayout");
    } 
    
    public ActionResult OtherAbout()
    {
        string myName = "Jignesh Trivedi";
        return View("About", "_otherLayout", myName);
    }
