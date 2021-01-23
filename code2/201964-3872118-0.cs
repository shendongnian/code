    [MetadataType(typeof(MyClassMetadata)]
    public partial class MyClass
    {
        public class MyClassMetadata
        {
             [StringLength(30)]
             public string FirstName {get;set;}
           
             [StringLength(30)]
             [Required]
             public string LastName {get;set;}    
        }
    }
