        public static void AddStudent(string student_name, string student_address)
        {
            DataDbContext dataDbContext = new DataDbContext();
            dataDbContext.Database.EnsureCreated();
            PropertyInfo[] fields = dataDbContext.myclass.GetType().GetProperties();
            PropertyInfo prop_name = fields[1];
            PropertyInfo prop_addr = fields[2];
            prop_name.SetValue(dataDbContext.myclass, student_name);
            prop_addr.SetValue(dataDbContext.myclass, student_address);
            dataDbContext.Add(dataDbContext.myclass);
            dataDbContext.SaveChanges();
        }
