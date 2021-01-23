    public class CheckLoggedIn : ActionFilterAttribute
    {
        public IGenesisRepository gr { get; set; }
        public Guid memberGuid { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /* how to get the controller*/
            var controllerUsingThisAttribute = ((GenesisController)ControllerContext.Controller);
         
            /* now you can use the public properties from the controller */
            gr = controllerUsingThisAttribute .genesisRepository;
            memberGuid = (controllerUsingThisAttribute .memberGuid;
            Member thisMember = gr.GetActiveMember(memberGuid);
            Member bottomMember = gr.GetMemberOnBottom();
            if (thisMember.Role.Tier <= bottomMember.Role.Tier)
            {
                filterContext
                    .HttpContext
                    .Response
                    .RedirectToRoute(new { controller = "Member", action = "Login" });
            }
            base.OnActionExecuting(filterContext);
        }
    }
