    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        public Service1()
        {
            Thread.CurrentPrincipal = HttpContext.Current.User;
        }
        [OperationContract]
        [PrincipalPermission(SecurityAction.Demand, Role = "Registered Users")]
        public string DoSomeWork()
        {
            return "working";
        }
    }
