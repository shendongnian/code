    [MetadataType(typeof(YourClassMetadata))]
    public partial class YourClass
    {       
         //buddyclass to entity class
        class YourClassMetadata {
         [Required(ErrorMessage="Your custom overriding error message")]
         public int NonNullablePropertyThatIsGivingYouProblems {get;set;}
        }
    }
