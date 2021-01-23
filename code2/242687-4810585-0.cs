    [MetadataType(typeof(EmployeeMetadata))]
        public partial class Employee
        {
            public class EmployeeMetadata
            {
                [Required(ErrorMessage="Employee Name is Required")]
                [StringLength(50, ErrorMessage="Must be under 30 Characters")]
                public string Name { get; set; }
             }
        }
