    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            Sql("create or replace trigger TR_CUSTOM ... ");
        }
        
        public override void Down()
        {
        }
    }
