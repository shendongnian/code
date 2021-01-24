        public DbSet<Student> Students { get; set; }
        //Create
            using (var context = new YourDataContext()) {
            
              var std = new Student()
               {
                  Name = "Aviansh"
                };
            
                 context.Students.Add(std);
                 context.SaveChanges();
                        }//Basically saving it will add a row in student table with name field as avinash 
    
    //Delete
    
         using (var context = new YourDataContext()) {
            
            var CurrentStudent=context.Students.FirstOrDefault(x=>x.Name=="Avinash")
            CurrentStudent.context.Students.Remove(CurrentStudent);
            context.SaveChanges();
    }
