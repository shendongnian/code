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
                    return results;
                }
            }
        }
    }
