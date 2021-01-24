    using System.ComponentModel.DataAnnotations;
        
    namespace JTableExampleNETFramework.Models
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
    
            [Required(ErrorMessage = "Full name Required")]
            public string Name { get; set; }
    
            [Required]
            public string City { get; set; }
    
            [Required]
            public string Department { get; set; }
    
            [Required]
            public string Gender { get; set; }
    
            public bool BulkUpdate { get; set; }
        }
    }
