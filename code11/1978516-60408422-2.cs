    namespace WebApiJoinData.Controllers
    {
    [RoutePrefix("Api")]
    public class JoinController : ApiController
    {
        DepartmentServicesEntities DSE = new DepartmentServicesEntities();
        [Route("Api")]
    
    
            [HttpGet]
            public object JoinStatement()
            {
                string Msg = String.Empty;
                string sql = String.Format("Select FirstName, LastName, Gender, Salary, E.Department_id, Department_Name from Employee E INNER JOIN Department D on D.department_id = E.department_id");
    
                using (DSE)
                {
                    //proceed the query and return Msg
                    var results = DSE.Database.SqlQuery<object>(sql).ToList();
                    //assign result as json to your string; but you cant return because your return type is not string
                    Msg = Newtonsoft.Json.JsonConvert.SerializeObject(results);
                    //since your return type is object and not string below can only be returned
                    return results;
                }
            }
        }
    }
