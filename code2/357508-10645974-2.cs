public partial class Initial : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Measurements",
            c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MTime = c.DateTime(nullable: false),
                    Value = c.Double(nullable: false),
                    TypeName = c.String(),
                })
            .PrimaryKey(t => t.Id);
            
    }
        
    public override void Down()
    {
        DropTable("dbo.Measurements");
    }
}
