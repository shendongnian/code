    public ActionResult Index()
    {
        string dataFromTheWinform = null;
        using (MyWinformsApp.Form1 temp = new MyWinformsApp.Form1())
        {
            temp.Show();
            temp.button1.PerformClick();
            dataFromTheWinform = temp.GetMyString();
            temp.Close();
        }
    
        ViewBag.MyString = dataFromTheWinform;
            
        return View("Index");
    }
