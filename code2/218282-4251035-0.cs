    [AspNetCompatibilityRequirementsAttribute(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class FooBar : IFooBar
    {
       public void DoSomething()
       {
           HttpContext context = HttpContext.Current;
           if (context != null)
           {
                 // Should get here now
           }
       }
    }
