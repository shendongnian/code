    [HttpPost]
    public ActionResult Foo(string show)
    {
        if (!string.IsNullOrEmpty(show))
        {
            // the form was submitted with the Show button
        }
        else
        {
            // ...
        }
        ...
    }
