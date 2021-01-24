c#
public partial class LinkIdColumn_v1 : DbMigration
{
    public override void Up()
    {
        AddColumn("a","LinkId",c=>c.Int());
        Sql("UPDATE SET a.LinkId= b.LinkId FROM b INNER JOIN a ON a.SomeKey = b.SomeKey");
        // Other generated code to create your FK
    }
    public override void Down()
    {
       // Generated code to drop the FK
    }
}
