    [HttpPost]
    public ActionResult Edit(Parent parent)
    {
        ModelState.Remove("Children");
        parent.Children = new List<Child>
        {
            new Child(4, false, "c"),
            new Child(5, true, "d")
        };
        return View(parent);
    }
