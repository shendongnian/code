    public class Employee: BasicEntity
        {
            [Column(Order=0)]
            [Required(ErrorMessage = "Name is required")]
            [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
            public string Name { get; set; }
            [Column(Order=1)]
            [Required(ErrorMessage = "Age is required")]
            public int Age { get; set; }
            [Column(Order=2)]
            [Required(ErrorMessage = "DOB is required")]
            public DateTime DOB { get; set; }
            [Required(ErrorMessage = "City is required")]
            public int City { get; set; }
            [Required(ErrorMessage = "State is required")]
            public int State { get; set; }
            [Required(ErrorMessage = "Country is required")]
            public int Country { get; set; }
        }
