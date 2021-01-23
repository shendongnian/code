    public virtual ActionResult ProductCart()
    {
        var applicationService = <obtain or create appropriate service instance>
        var userID = <obtain user ID or similar from session state>
        var viewModel = applicationService.GetProductCartModel( userID );
        return View( "Cart", viewModel );
    }
