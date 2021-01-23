        public static void Delete(Employee employee)
        {
            using (ISession session = FNH_Manager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (employee.Id != 0) 
                    { 
                      Employee emp = session.Get<Employee>(employee.Id);
                    
                      if (emp != null)
                      {
                        emp.Store.Staff.Remove(emp);
                        session.Delete(emp);
                        transaction.Commit();
                      } 
                    }
                }
            }
        } 
