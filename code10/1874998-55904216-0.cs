    migrationBuilder.CreateTable(
                name: "SMSCodeInfo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSCodeInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_SMSCodeInfo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
