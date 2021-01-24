public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ProductID { get; set; }
    public string Name { get; set; }
}
not: if you want string Primary Key (or manually add Id) you should use `[DatabaseGenerated(DatabaseGeneratedOption.None)]`
[more examples about EF](https://www.entityframeworktutorial.net/code-first/databasegenerated-dataannotations-attribute.aspx) (select EF version from navigator)
