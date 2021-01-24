[TestInitialize]
public void TestInit()
{
    using (var db = new MyDataContext())
        db.Database.EnsureDeleted(); // reset database before each test
}
[TestMethod]
public void Migrate_Version1_To_Version2_On_Populated_Database()
{
    using (var db = new MyDataContextVersion1())
        db.Database.Migrate(); // create database and apply migrations up through Version 1
    // populate the Version 1 database
    App.InitializeDatabase(); // whatever method you would normally call to read/update the database
    // assert statements to test that the Version 2 database looks like you expect.
}
where `InitializeDatabase()` looks something like:
public void InitializeDatabase()
{
    using (var db = new MyDataContext())
    {
        db.Database.Migrate();
    
        // detect if upgrade needed and set new columns
        
        db.SaveChanges(); 
    }
}
Note that this solution is in part motivated by using SQLite, which does not support dropping columns in a migration. It discouraged me from trying to do anything more fancy inside the migrations.
