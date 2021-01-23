    namespace Project.Models
    {
        public class EmployeeReferral : Person
        {
            
            public int EmployeeReferralId { get; set; }
    
            
            //Company District
            //List                
            [Required(ErrorMessage = "Required.")]
            [Display(Name = "Employee District:")]
            public int? DistrictId { get; set; }
    
        public virtual District District { get; set; }       
    }
    namespace Project.Models
    {
        public class District
        {
            public int? DistrictId { get; set; }
    
            [Display(Name = "Employee District:")]
            public string DistrictName { get; set; }
        }
    }
