    public static List<Employee> FireEmployees()
    {
        using (var context = new hr_employeeEntities())
        {
            var employees = context.F_Emp
                .Where(x => x.employment_status == "A")
                .ToList();
            return employees;
        }
    }
