    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    
        namespace DataRepository
        {
            [MetadataType(typeof(Company_validation))]
            public partial class Company
            {
            }
        
            
            public class Company_validation
            {
                [Required]
                [DisplayName("Company name")]
                public string Name { get; set; }
        
                [Required]
                [DisplayName("Address")]
                public string AddressLine1 { get; set; }
                public string AddressLine2 { get; set; }
        
                [Required]
                public string Suburb { get; set; }
        
                [Required]
                public int Postcode { get; set; }
        
                [Required]
                public string State { get; set; }
            }
        
        }
