        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Table_PrincipalTable_TableId",
                table: "Table",
                column: "PrincipalTableId",
                principalTable: "PrincipalTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade)
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_PrincipalTable_TableId",
                table: "Table");
        }
