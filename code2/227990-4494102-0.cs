    public PartialViewResult MyActionIWantToTest(string someParameter)
    {
       var viewModel = new MyPartialViewModel { SomeValue = someParameter };
       return PartialView("MyPartialView", viewModel);
    }
