    public FooController: RESTController<Foo>
    {
        ...
        public override JsonResult Create(Foo obj)
        {
            throw new NotImplementedException();
        }
        ...
    }
