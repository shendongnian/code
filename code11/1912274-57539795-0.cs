    public partial class _20190817_2317 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMTransactions_tblMTransactions_OriginalTransactionId",
                table: "tblMTransactions");
            migrationBuilder.DropIndex(
                name: "IX_tblMTransactions_OriginalTransactionId",
                table: "tblMTransactions");
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMTransactions",
                table: "tblMTransactions");
            migrationBuilder.AlterColumn<long>(
                name: "OriginalTransactionId",
                table: "tblMTransactions",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "tblMTransactions",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMTransactions",
                table: "tblMTransactions",
                column: "Id");
            migrationBuilder.CreateIndex(
                name: "IX_tblMTransactions_OriginalTransactionId",
                table: "tblMTransactions",
                column: "OriginalTransactionId");
            migrationBuilder.AddForeignKey(
                name: "FK_tblMTransactions_tblMTransactions_OriginalTransactionId",
                table: "tblMTransactions",
                column: "OriginalTransactionId",
                principalTable: "tblMTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OriginalTransactionId",
                table: "tblMTransactions",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "tblMTransactions",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
