    [JsonConfigFilter]
    public ActionResult<Foo> SomeAction()
    {
        return new Foo
        {
            Bar = "hello"
        };
    }
