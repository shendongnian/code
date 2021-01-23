    public class ProdOnlyRequireHttpsAttribute : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!Statics.IsPROD()) return;
            base.OnAuthorization(filterContext);
        }
    }
