     public class PersonDto
            {
                [Required(ErrorMessage = "Please enter name")]
                public string name { get; set; }
                [Required(ErrorMessage = "Please enter date")]
                public DateTime dateOfBirth { get; set; }
            }
