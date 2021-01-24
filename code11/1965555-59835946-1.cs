    Private void savetoDB(List<Employee> employees)
    {
         using (MYDB em = new MYDB)
         {
            em.Employee.AddRange(employees);
            em.SaveChanges();
          }
     }
