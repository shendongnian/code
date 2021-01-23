    using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using StringlenghtMVC.Comman;
        using System.Web.Mvc;
    
    using System.Collections;
    
        [MetadataType(typeof(EmployeeMetaData))] //here we call metadeta class
        public partial class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public Nullable<int> Age { get; set; }
            public string Gender { get; set; }
            public Nullable<System.DateTime> HireDate { get; set; }
    
           //[CompareAttribute("Email")]
            public string ConfirmEmail { get; set; }
        }
    
        public class EmployeeMetaData
        {
            [StringLength(10, MinimumLength = 5)]
            [Required]
            //[RegularExpression(@"(([A-za-Z]+[\s]{1}[A-za-z]+))$", ErrorMessage = "Please enter Valid Name")]
            public string Name { get; set; }
    
            [Range(1, 100)]
            public int Age { get; set; }
            [CurrentDate]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime HireDate { get; set; }
    
            //[RegularExpression(@"^[\w-\._\%]+@(?:[\w]{2,6}$")]
            public string Email { get; set; }
    
            [System.Web.Mvc.CompareAttribute("Email")]
            public string ConfirmEmail { get; set; }
           
    
        }
