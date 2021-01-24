    public ActionResult TestAction1(ClassA model)
    {
        model.Id = "1";
        model.Name = "test";
        model.Marks.Grade = "A";
        model.Marks.Marks = 100;
        var complexObj = JsonConvert.SerializeObject(model);
        TempData["newuser"] = s;
        return RedirectToAction("TestAction2");
    }
    public ActionResult TestAction2()
    {
        if (TempData["newuser"] is string complexObj )
        {
            var newUser = JsonConvert.DeserializeObject<ClassA>(complexObj);
        }
        return View();
    }
