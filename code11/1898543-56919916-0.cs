     public class PersonDto
            {
                [Required(ErrorMessage = "Please enter name")]
                public string name;
                [Required(ErrorMessage = "Please enter date")]
                public DateTime dateOfBirth;
            }
