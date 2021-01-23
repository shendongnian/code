        public partial class identity_fix : DbMigration
        {
            public override void Up()
            {
                AlterColumn("dbo.LogEmailAddressStatsFails", "Id", c => c.Int(nullable: false, identity: true));
            }
            
            public override void Down()
            {
                AlterColumn("dbo.LogEmailAddressStatsFails", "Id", c => c.Int(nullable: false));
            }
        }
