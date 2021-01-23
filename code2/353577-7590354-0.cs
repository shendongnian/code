    public class myClass()
    {
    
        [Display(Name="Date of Birth"), DataType(DataType.Date, ErrorMessage = "Please enter a valid date for the Date of Birth.")]
        public string dateOfBirth { get; set; }
    }
