static EntityContext()
{
//for example to create a db:
Database.SetInitializer(new CreateDatabaseIfNotExists<EntityContext>());
}
