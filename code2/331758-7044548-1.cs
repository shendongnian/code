    public static class ControllerExtensions
    {
        public static CustomPrincipal CustomPrincipal(this Controller controller)
        {
            if(controller.User is CustomPrincipal)
            {
                return controller.User as CustomPrincipal;
            }
            return null; // maybe return an empty object instead to get around null reference...
        }
    }
