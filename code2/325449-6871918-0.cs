    public ActionResult FooAction
    {
         FooViewModel model = new FooViewModel()
         {
              Foo = InternalClass.Foo
         };
    
         return View(model);
    }
