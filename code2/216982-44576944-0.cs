    ExampleEntity exampleEntity = dbcontext.ExampleEntities.Attach(new ExampleEntity { Id = 1 });
    exampleEntity.ExampleProperty = "abc";
    dbcontext.Entry<ExampleEntity>(exampleEntity).Property(ee => ee.ExampleProperty).IsModified = true;
    dbcontext.Configuration.ValidateOnSaveEnabled = false;
    dbcontext.SaveChanges();
