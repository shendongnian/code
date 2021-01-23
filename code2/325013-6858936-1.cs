    pubilc ActionResult SomeAction()
    {
        SomeViewModel model = ...
        return PartialView(model);
    }
