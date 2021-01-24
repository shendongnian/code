    public ActionResult Act(ActVM viewModel)
    {
        switch (ControllerContext.ActionDescriptor.AttributeRouteInfo.Name)
        {
            // ...
        }
        return View(viewModel);
    }
