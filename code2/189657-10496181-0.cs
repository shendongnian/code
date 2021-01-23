     public sealed class TestPropertyAttribute : System.Attribute
    {
        [System.ComponentModel.DataAnnotations.StringLength(50),Required]
        public string Name
        {
            get { return _name; }
            set
      { 
             if (String.IsNullOrEmpty(value)) throw new InvalidDataException("Name is a madatory property,  please fill it out not as null or string.Empty thanks"); }
           else
          _name= value;
        
      }
           string _name;
     }
