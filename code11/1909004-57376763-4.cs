    public ActionResult TestAction1(ClassA model)
    {
        model.Id = "1";
        model.Name = "test";
        model.Marks.Grade = "A";
        model.Marks.Marks = 100;
        var complexObj = JsonConvert.SerializeObject(model);
        TempData["newuser"] = complexObj;
        return RedirectToAction("TestAction2");
    }
    public ActionResult TestAction2()
    {
        if (TempData["newuser"] is string complexObj )
        {
            var getModel= JsonConvert.DeserializeObject<ClassA>(complexObj);
        }
        return View();
    }
