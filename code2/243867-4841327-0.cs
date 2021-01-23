    public class EmployeeValidator : ValidationDef<Employee>
    {
        public EmployeeValidator()
        {
            Define(x => x.FullName).IsValid();
            Define(x => x.FullName).NotNullable(); // Not sure if you need this
        }
    }
