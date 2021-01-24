 c#
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerID { get; set; }
    public string Name { get; set; }
    public string PrimaryContact { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid ResellerId { get; set; }
    [ForeignKey("ResellerId")]
    public Reseller Reseller { get; set; }  
}
then change the ResellerId 
