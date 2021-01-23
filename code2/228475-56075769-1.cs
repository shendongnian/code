    public void leftrighjoin(){
                   Project P1 = new Project() { ProjectID = 1, ProjectName = "UID" };
                    Project P2 = new Project() { ProjectID = 2, ProjectName = "RBS" };
                    Project P3 = new Project() { ProjectID = 3, ProjectName = "XYZ" };
                    // Employee List
                    List<Employee> ListOfEmployees = new List<Employee>();
                    ListOfEmployees.AddRange((new Employee[] 
                    { 
                        new Employee() { ID = 1, Name = "Sunil",  ProjectID = 1 }, 
                        new Employee() { ID = 1, Name = "Anil", ProjectID = 1 },
                        new Employee() { ID = 1, Name = "Suman", ProjectID = 2 },
                        new Employee() { ID = 1, Name = "Ajay", ProjectID = 3 },
                        new Employee() { ID = 1, Name = "Jimmy", ProjectID = 4 }}));
                    
                    //Project List
                    List<Project> ListOfProject = new List<Project>();
                    ListOfProject.AddRange(new Project[] { P1, P2, P3 });
                   
                    //Left join
                    var Ljoin = from emp in ListOfEmployees
                                join proj in ListOfProject
                                   on emp.ProjectID equals proj.ProjectID into JoinedEmpDept
                                from proj in JoinedEmpDept.DefaultIfEmpty()
                                   select new
                                   {
                                       EmployeeName = emp.Name,
                                       ProjectName = proj != null ? proj.ProjectName : null
                                   };
        
                    //Right outer join
                    var RJoin = from proj in ListOfProject
                                    join employee in ListOfEmployees
                                    on proj.ProjectID equals employee.ProjectID into joinDeptEmp
                                    from employee in joinDeptEmp.DefaultIfEmpty()
                                    select new
                                    {
                                        EmployeeName = employee != null ? employee.Name : null,
                                        ProjectName = proj.ProjectName
                                    };
        
                    //Printing result of left join
                    Console.WriteLine(string.Join("\n", Ljoin.Select(emp => " Employee Name = " +
        emp.EmployeeName + ", Project Name = " + emp.ProjectName).ToArray<string>()));
                    
                    //printing result of right outer join
                    Console.WriteLine(string.Join("\n", RJoin.Select(emp => " Employee Name = " +
        emp.EmployeeName + ", Project Name = " + emp.ProjectName).ToArray<string>()));
    }
