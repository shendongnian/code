    public static List<Employee> LoadEmployees()
    {
            List<Employee> emp = new List<Employee>(); // basically you have created new List<Employee> which is at the moment is empty. so if you try to do emp[0].Name, you will get exception
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Open();                   
                    string query = "select * from Employee;"; // fetching employees from database
                    SQLiteCommand cmd = new SQLiteCommand(query, cnn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Employee e = new Employee(); // create new instance of employee object and initialize it's members and then add it in emp object.
                            e.Id = reader.GetString(0);
                            e.Name = reader.GetString(1);
                            e.Gender = reader.GetString(2);
                            e.Department = reader.GetString(3);
                            e.Doj = reader.GetString(4);
                            e.Email = reader.GetString(5);
                            e.Phone = reader.GetString(6);
                            emp.Add(e);
                        }
                    }
                    return emp;
                }
            }
            catch (Exception ex)
            {
                emp = null;
                return emp;
            }
        }
