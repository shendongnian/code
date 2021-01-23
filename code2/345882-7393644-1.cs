    public ActionResult Foo()
    {
        BlogContentModel model = ....
        model.MarkDown = new MarkdownTextAreaModel
        {
            Name = "contect"
        };
        return View(model);
    }
