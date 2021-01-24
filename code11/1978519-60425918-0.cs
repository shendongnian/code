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
                using (DSE)
                {
                    var result = (from e in DSE.employees
                                  join d in DSE.departments on e.department_id equals d.department_id
                                  join ws in DSE.workingshifts on e.shift_id equals ws.shift_id
                                  select new
                                  {
                                      FirstName = e.FirstName,
                                      LastName = e.LastName,
                                      Gender = e.Gender,
                                      Salary = e.Salary,
                                      Department_id = e.department_id,
                                      Department_Name = d.department_name,
                                      Shift_id = ws.shift_id,
                                      Duration = ws.duration,
                                  }).ToList();
                    // TODO utilize the above result
                    
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
                    return result;
                }
            }
        }
    }
