    using Migrator.Framework;
    using System.Data;
    
    namespace DBMigration
    {
            [Migration(20080401110402)]
            public class CreateUserTable_001 : Migration
            {
                    public void Up()
                    {
                            Database.CreateTable("User",
                                    new Column("UserId", DbType.Int32, ColumnProperties.PrimaryKeyWithIdentity),
                                    new Column("Username", DbType.AnsiString, 25)
                                    );
                    }
    
                    public void Down()
                    {
                            Database.RemoveTable("User");
                    }
            }
    }
