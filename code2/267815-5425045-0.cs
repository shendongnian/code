    public interface IEmployeeRepository<T>
        where T : Employee
    {
        DataTable Employees { get; }
        void SaveEmployee(T employee);
        void DeleteEmployee(T employee);
    }
    public class DevelopersRepository : IEmployeesRepository<Developer>
    {             
        public void SaveEmployee(Developer employee)
        {
            Database db = new SqlDatabase(connectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Developers_Insert",   employee.ProgrammingLanguage);
            db.ExecuteNonQuery(dbCommand);
        }
    }
