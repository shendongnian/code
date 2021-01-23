        public static void Delete(Employee employee)
        {
            using (ISession session = FNH_Manager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (Employee.Id != 0)
                    {
                      var emp =  session.Get(typeof(Employee), employee.Id);
                        
                      if (emp != null)
                      {
                        session.Delete(emp);
                        transaction.Commit();
                      }
                    }
                }
            }
        } 
