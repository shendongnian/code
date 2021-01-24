    public static List<Employee> FireEmployees()
    {
        using (var context = new hr_employeeEntities())
        {
            var employees = context.HR_EMPLon
                .Join(context.F_Emp, 
                    h => h.EMPLID, 
                    e => e.employee_id.ToString(),
                    (h, e) => new {HREmployee = h, FEmployee = e})
                .Where(x => x.FEmployee.employment_status == "A")
                .Select(x => x.HREmployee)
                .ToList();
            return employees;
        }
    }
