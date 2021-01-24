    namespace MobileAppsService.Controllers
        {
            public class ValuesController : ApiController
            {
                readonly IParameterSets Iparamset;
                public ValuesController()
                {
                    Iparamset = new ParameterSets();
                }
        
                // GET api/values
                public IEnumerable<ParameterSet> GetAlldata()
                {
                    
                   var paramList = Iparamset.ListofParameterSet();
                   //do encryption of the paramlist here 
                   //return the encrypted paramlist
                   return paramList;
                }
            }
        }
