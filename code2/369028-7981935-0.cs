    public class PersonMetaData
    {
        [Required(ErrorMessage = "nima", AllowEmptyStrings = false)]
        public global::System.String ProductName { set; get; }
    
        [Range(minimum: 10, maximum: 100, ErrorMessage = "NIIMMMAA")]
        public global::System.Int32 ProductID { set; get; }
    }
