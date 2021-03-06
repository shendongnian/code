    public partial class AddUniqueIndexes : DbMigration
    {
        public override void Up()
        {
            //Sql Server limits indexes to 900 bytes, 
            //so we need to ensure cumulative field sizes do not exceed this 
            //otherwise inserts and updates could be prevented
            //http://www.sqlteam.com/article/included-columns-sql-server-2005
            AlterColumn("dbo.Answers",
                "Text",
                c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.ConstructionTypes",
                "Name",
                c => c.String(nullable: false, maxLength: 300));
            //[IX_Text] is the name that Entity Framework would use by default
            // even if it wasn't specified here
            CreateIndex("dbo.Answers",
                "Text",
                unique: true,
                name: "IX_Text");
            //Default name is [IX_Name_OrganisationID]
            CreateIndex("dbo.ConstructionTypes",
                new string[] { "Name", "OrganisationID" },
                unique: true);
        }
        public override void Down()
        {
            //Drop Indexes before altering fields 
            //(otherwise it will fail because of dependencies)
            //Example of dropping an index based on its name
            DropIndex("dbo.Answers", "IX_Text");
            //Example of dropping an index based on the columns it targets
            DropIndex("dbo.ConstructionTypes", 
                new string[] { "Name", "OrganisationID" }); 
            
            AlterColumn("dbo.ConstructionTypes",
                "Name",
                c => c.String(nullable: false));
            AlterColumn("dbo.Answers",
                "Text",
                c => c.String(nullable: false, maxLength: 500));
    }
