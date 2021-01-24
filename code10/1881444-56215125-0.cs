    public class CustomValidateAntiforgeryTokenAuthorizationFilter : ValidateAntiforgeryTokenAuthorizationFilter
    {
        public CustomValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery, ILoggerFactory loggerFactory)
            :base(antiforgery, loggerFactory)
        {
        }
        protected override bool ShouldValidate(AuthorizationFilterContext context)
        {
            var filters = context.Filters;
            if (filters.Where(f => f.GetType() == typeof(IgnoreAntiforgeryTokenAttribute)) != null)
            {
                return false;
            }
            else
            {
                return base.ShouldValidate(context);
            }
        }
    }
