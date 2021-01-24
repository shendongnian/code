    public class HasPermissionAttribute : TypeFilterAttribute // Changed parent class
    {
        public HasPermissionAttribute(int value)
            : base(typeof(HasPermissionAsyncFilter))
        {
            Arguments = new object[] { value };
        }
    }
    public class HasPermissionAsyncFilter : IAsyncActionFilter
    {
        private readonly int _permissionValue;
        public HasPermissionAsyncFilter(int permissionValue)
        {
            _permissionValue = permissionValue;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // -------------Need to use the values passed from the attribute-------
            var x = _permissionValue;
        }
    }
