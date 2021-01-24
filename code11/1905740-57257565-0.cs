public partial class ResetJobSites : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobSites", "JobSiteID", "dbo.Jobs");
            DropIndex("dbo.JobSites", new[] { "JobSiteID" });
            DropTable("dbo.JobSites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobSites",
                c => new
                    {
                        JobSiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobSiteID);
            
            CreateIndex("dbo.JobSites", "JobSiteID");
            AddForeignKey("dbo.JobSites", "JobSiteID", "dbo.Jobs", "JobIb");
        }
    }
PM> update-database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201907291444500_ResetJobSites].
Applying explicit migration: 201907291444500_ResetJobSites.
Applying automatic migration: 201907291528423_AutomaticMigration.
PM> 
So to summarize: To convert a one-to-one to a one-to-many relationship when automatic migrations are turned on, and you need to preserve a production database (but willing to accept the loss of data on the table you're converting).
- Create an explicit migration to uncouple the two tables (I did this by commenting out the class, the nav property on the Job table, the DbSet in the DbContext, and whatever else it took to build the project).
- Make the changes model, add the nav property back to the Job table, an ICollection nav property, add the DbSet back to the DbContext, and let auto migrations run their course.
- Don't get yourself in this position in the first place.
