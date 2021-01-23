    namespace MyApplication.Migrations
    {
        using System;
        using System.Data.Entity.Migrations;
    
        public partial class SomethingMeaningful_sp_DoSomething : DbMigration
        {
            public override void Up()
            {
                this.Sql(Properties.Resources.Create_sp_DoSomething);
            }
        
            public override void Down()
            {
                this.Sql(Properties.Resources.Drop_sp_DoSomething);
            }
        }
    }
