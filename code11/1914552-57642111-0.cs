    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
        public int ID { get; set; }
        public string Name { get; set; }
        [HttpGet("Data")]
        public List<Employee> GetData()
        {
            var empList = new List<Employee>()
            {
                new Employee { ID=1, Name="Hamdi"},
                new Employee { ID=2, Name="Tester"}
            };
            return empList ;
        }
    }
