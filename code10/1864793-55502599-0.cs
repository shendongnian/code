    [RoutePrefix("Api/Incident")]
    public class IncidentController : TaskController
    {
        //Get an individual incident by ID
        [HttpGet]
        public GenericIncidentGet Get(string id)
        {
            return GenericIncidentWf.GenericIncidentGet(ControllerContext.ControllerDescriptor.ControllerName, System.Threading.Thread.CurrentPrincipal.Identity.Name, id);
        }
    }
