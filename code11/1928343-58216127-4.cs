    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            //Ensures that the database for the context does not exist. If it does not exist, no action is taken. 
            //If it does exist then the database is deleted.
            //Warning: The entire database is deleted an no effort is made to remove just the database objects that are used by the model for this context.
            context.Database.EnsureDeleted();
            //create the database
            context.Database.EnsureCreated();
            
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }
            var students = new Student[]
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
           
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            //Applies any pending migrations for the context to the database.Will create the database if it does not already exist.
            //Note that this API is mutually exclusive with DbContext.Database.EnsureCreated().
            //EnsureCreated does not use migrations to create the database and therefore the
            //database that is created cannot be later updated using migrations.
            context.Database.Migrate();
        }
    }
