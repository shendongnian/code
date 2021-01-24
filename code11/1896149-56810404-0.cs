    Database.SetInitializer(new NullDatabaseInitializer<ExamDbContext>());
    // Forces initialization of database on model changes.
    using (var context= new ExamDbContext ()) {
       context.Database.Initialize(false);
    }    
