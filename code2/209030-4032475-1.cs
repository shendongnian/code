    public class NavigationAttribute:Attribute{
      public Navigation Place {get;set;}
    }
    [Navigation(Place=Navigation.Top)]
    public ActionResult Whatever(){}
