    public class Request
    {
        [Required]
        [Range(10, 20]
        public int? Field1 {get; set;}
    
        [Range(10, 20]
        public MyStruct Field2 {get; set;}
    }
