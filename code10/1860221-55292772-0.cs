     public class ConditionalAuthorizationAttribute : AuthorizeAttribute
        {
            public static bool FlipFlop = true;
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                FlipFlop = !FlipFlop;
                return FlipFlop;
            }
    }
