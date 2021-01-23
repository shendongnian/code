    public interface IRepository
    {
          IEnumerable<EmployeeProfiles> EmployeeProfiles { get; }
    }
    public class Repository
    {
        public IEnumerable<EmployeeProfiles> EmployeeProfiles
        {
            get
            {
                // Get all the entities including children     
                using (MyContext context = new MyContext())     
                {
                    return context.EmployeeProfiles.Include("EmployeeProperties").ToList();     
                }
            }
        }
    }
