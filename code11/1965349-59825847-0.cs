public partial class Person
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ID { get; set; }
  public string FirstName { get; set; }
  public int Age { get; set; }
}
The `DatabaseGeneratedOption.Identity` option tells EF Core that the database generates new values when a record is inserted. Without this, EF Core would include the value of the `ID` property in the `INSERT` command
