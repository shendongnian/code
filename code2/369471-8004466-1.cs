    public List<Employee> Handle(string filePath)
            {
                List<Employee> empLst = new List<Employee>();
    
                ExcelParser exlParser = new ExcelParser();
                try
                {
                    if (exlParser.Load(filePath))
                    {
                        int rowCount = exlParser.GetRowCount();
                        for (int i = 2; i <= rowCount; i++)
                        {
                            Employee emp = new Employee();
    
                            emp.FirstName = exlParser.GetValue(i, 1);
                            emp.LastName  = exlParser.GetValue(i, 2);
                            emp.EmpID     = exlParser.GetValue(i, 3);
    
                            empLst.Add(emp);                       
                        }
                    }
                }
                catch (Exception exp)
                {
                }
                finally
                {
                    exlParser.Dispose();
                }
    
                return empLst;
            }
