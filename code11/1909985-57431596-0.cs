     protected override void Up(MigrationBuilder migrationBuilder)
     {
        			migrationBuilder.CreateTable(
        				name: "AspNetRoles",
        				columns: table => new
        				{
        					Id = table.Column<string>(nullable: false),
        					Name = table.Column<string>(maxLength: 256, nullable: true),
        					NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
        					ConcurrencyStamp = table.Column<string>(nullable: true),
        					Discriminator = table.Column<string>(nullable: false)
        				},
        				constraints: table =>
        				{
        					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
        				});
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
    			migrationBuilder.DropTable(
    				name: "AspNetRoleClaims");
    }
