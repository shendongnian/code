    protected void Page_Load(object sender, EventArgs e)
{        
        Employee objEmp1 = new Employee("Rahul", "Software");
        Employee objEmp2 = new Employee("Rahul", "Software");
        Employee objEmp3 = new Employee("Rahul", "Back Office");
        Employee objEmp5 = new Employee("Rahul", "Back Office");
        Employee objEmp4 = new Employee("Rahul", "Engineer");
        Employee objEmp6 = new Employee("Rahul", "Engineer");
        Employee objEmp7 = new Employee("Rahul", "Test");
        List<Employee> lstEmployee = new List<Employee>();
        lstEmployee.Add(objEmp1);
        lstEmployee.Add(objEmp2);
        lstEmployee.Add(objEmp3);
        lstEmployee.Add(objEmp4);
        lstEmployee.Add(objEmp5);
        lstEmployee.Add(objEmp6);
        lstEmployee.Add(objEmp7);
		// TO GET THE GENERIC ITEMS
        List<Employee> lstDistinct = Distinct(lstEmployee);
    }
    public static List<Employee> Distinct(List<Employee> collection)
    {
        List<Employee> distinctList = new List<Employee>();
        foreach (Employee value in collection)
        {
            if (!distinctList.Exists(delegate(Employee objEmp) { return objEmp.Designation == value.Designation; }))
            {
                distinctList.Add(value);
            }
        }
        return distinctList;
    }
