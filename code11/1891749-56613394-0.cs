c#
public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
    public string Foo { get; set; }
}
then we want to delete `Foo`. First, delete the `Blog.Foo` class property shown above then add a migration to generate a `Migration` class. Since `MigrationBuilder.DropColumn` is not supported in SQLite, we should modify the migration method as described in the documentation.
c#
protected override void Up(MigrationBuilder migrationBuilder)
{
    // Create temporary Blog table with new schema
    migrationBuilder.CreateTable(
        name: "Blog_temp_new",
        columns: table => new
        {
            BlogId = table.Column<int>(nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Blog", x => x.BlogId);
        });
    // Copy Blog to Blog_temp_new
    migrationBuilder.Sql("INSERT INTO Blog_temp_new (BlogId, Name) SELECT BlogId, Name FROM Blog;");
    // Delete Blog
    migrationBuilder.DropTable("Blog");
    // Rename Blog_temp_new to Blog
    migrationBuilder.RenameTable("Blog_temp_new", newName: "Blog");
}
All the `Blog` data with its `BlogId` and `Name` will be preserved upon calling `Database.Migrate`.
> Is it worth the effort
Based from my experience, Yes! I find Model-First easier to work with compared to Database-First. I prefer doing everything in C# as much as possible but if you're a SQL expert then maybe you would have a different view than mine. :)
