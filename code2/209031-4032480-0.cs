    enum Navigation 
    {
        Top = 0,
        Left = 2,
        Footer = 3,
    }
    class NavigationAttribute: Attribute
    {
        Navigation _nav;
        public NavigationAttribute(Navigation navigation){
            _nav = navigation;
        }
    }
    ...
    [Navigation(Navigation.Top)]
    public ActionResult Quotes()
    {
        return View();
    }
