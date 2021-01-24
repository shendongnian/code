    public partial class DatetimeOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Message>(nameof(Message.SendingDate), nameof(Message), nameof(DateTimeOffset));
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Message>(nameof(Message.SendingDate), nameof(Message), "datetime2(7)");
        }
    }
