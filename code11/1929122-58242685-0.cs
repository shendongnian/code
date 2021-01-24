public partial class EmployeePermissions
{
    // add the [Key] annotation to indicate the primary key of the class/table
    [Key]
    // add the [DatabaseGenerated(..)] annotation to indicate an IDENTITY column in the table
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PkEmployeePermissions { get; set; }
    public int FkEmployee { get; set; }
    public int FkPermission { get; set; }
    public Employee FkEmployeeNavigation { get; set; }
    public Permission FkPermissionNavigation { get; set; }
}
Now you should be able to insert those objects, and have them stored properly in your SQL Server table.
