    public partial class test2 : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.AddColumn<string>(
                    name: "NewColumn",
                    table: "AspNetRoles",
                    nullable: true);
            }
            protected override void Down(MigrationBuilder migrationBuilder)
            {
              
                migrationBuilder.DropColumn(
                    name: "NewColumn",
                    table: "AspNetRoles");
            }
        }
