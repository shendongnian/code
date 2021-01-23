    public class FullNameValidator : ValidationDef<FullName>
    {
        public EmployeeValidator()
        {
            Define(x => x.FirstName).NotNullable();
            Define(x => x.LastName).NotNullable();
        }
    }
