    public class JoinController: ApiController
    {
    DepartmentServicesEntities DSE = new DepartmentServicesEntities();
    [Route("Api")]
        [HttpGet]
        public object JoinStatement()
        {
            using (DSE)
            {
                var result = (from e in DSE.employee join d 
                in DSE.department on e.department_id equals d.department_id 
                select new {
                FirstName = e.FirstName, 
                LastName = e.LastName, 
                Gender = e.Gender, 
                Salary = Salary, 
                Department_id = e.Department_id, 
                Department_Name = d.Department_Name
                }).ToList();
            // TODO utilize the above result
            }
        }
    }
    
