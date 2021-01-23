    public ActionResult Register(int id, string sl)
    {
        MyModel myModel = new MyModel();
        myModel.id = id;
        myModel.sl = sl;
        return View(myModel);
    }
