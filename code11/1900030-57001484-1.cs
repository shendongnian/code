    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public void DownloadToXML()
        {
            
            List<Employee> emList = _context.Employees.ToList();
            if (emList.Count > 0)
            {
                var xEle = new XElement("Employees",
                    from emp in emList
                    select new XElement("Employee",
                        new XElement("EmployeeID", emp.Id),
                        new XElement("CompanyName", emp.Name),
                        new XElement("DateOfBirth", emp.DateOfBirth),
                        new XElement("DateWhenJoined", emp.DateWhenJoined)
                      
                        ));
                xEle.Save("test.xml");
               
            }
        }
    }
