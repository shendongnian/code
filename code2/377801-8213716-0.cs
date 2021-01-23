     public class FooModel{
         
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}"]
            public DateTime RequestedStartDate{
                 get; set;
            }
            [Required]
            public decimal RequestedPayRate{
                 get; set;
            }
     }
