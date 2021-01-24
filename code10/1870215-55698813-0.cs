    public static class EmployeeExtentions
    {
        public static List<Employee> FireEmployees(this List<Employee> AllCitiesEmps)
        {
            List<Employee> employees = new List<Employee>();
    
            using (var ctx = new hr_employeeEntities())
            {
                var emp = (from x in ctx.F_Emp
                           join y in ctx.HR_EMPL on (x.employee_id).ToString() equals y.EMPLID
                           where x.employment_status == "A"
                           select new
                           {
                               x.employee_id,
                               x.employment_status,
                               //x.OtherProperties
                               y.EMPLID,
                               //y.OtherProperties
                           }).ToList();
    
                employees = emp.Select(x => (new EmployeeDerived { EmployeeId = x.employee_id, EmploymentStatus = x.employment_status }) as Employee).ToList();
    
            }
            return employees;
        }
    
        private class EmployeeDerived : Employee
        {
    
        }    
    }
