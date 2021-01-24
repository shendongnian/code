c#
protected override void Up(MigrationBuilder migrationBuilder)
{
    // before any manipulations:
    // create a backup table and copy data from the original column
    // assuming MyId is the primary key in the original table
    migrationBuilder.Sql(@"
        SELECT *
        INTO MyNewBackupTable
        FROM (SELECT MyId, MyNullableColumn FROM MyOriginalTable)
    "); 
   
    // ... perform the desired manipulations 
}
protected override void Down(MigrationBuilder migrationBuilder)
{
    // ... revert other manipulations,
    // (including making the column nullable again)
    // update the column from the data in the backup table
    migrationBuilder.Sql(@"
        UPDATE MyOriginalTable
        SET t1.MyNullableColumn = t2.MyNullableColumn
        FROM MyOriginalTable AS t1
        INNER JOIN MyNewBackupTable AS t2
        ON t1.MyId = t2.MyId 
    ");
    // remove the backup table
    migrationBuilder.Sql(@"DROP TABLE MyNewBackupTable");
}
You can also delete the backup in one of subsequent migrations (`Up`) if the requirements allow you defining a "point of no return".
