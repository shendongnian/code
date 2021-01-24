    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly PermissionAction[] permissionActions;
    
        public CustomAuthorize(PermissionItem item, params PermissionAction[] permissionActions)
        {
            this.permissionActions = permissionActions;
        }
    
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var currentIdentity = System.Threading.Thread.CurrentPrincipal.Identity;
            if (!currentIdentity.IsAuthenticated) {
                // no access
            }
     
            bool myCondition = "money" == "happiness"; 
            if(myCondition){
               // do your magic here...
            }
            else{
              // another magic...
           }           
        }
    }
