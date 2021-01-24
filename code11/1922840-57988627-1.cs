    public ActionResult Index()
        {
            TestDropDown tdd = new TestDropDown();
            tdd.MuValue = DropDownValue.A;
            tdd.ShowMe = 0;           
            return View(tdd);
        }
