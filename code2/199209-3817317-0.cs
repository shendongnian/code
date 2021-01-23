    [MetadataType(typeof(Contact_Validate))]
    public partial class Contact
    {
        public string FullName()
        {
            return _FirstName + " " + _SecondName;
        }
     
    }
    public class Contact_Validate
    {
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SecondName { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
    }
