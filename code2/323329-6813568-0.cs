    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
      private class EmployeeMetadata
      {
         [Required]
         public object Name; // Type doesn't matter, it is just a marker
      }
    }
