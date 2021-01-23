    public class Entity
    {
        [Required, MaxStringLength(50)]
        public string Property1 { get; set; }  
        [Between(5, 20)]
        public int Property2 { get; set; }
        
        [ValidateAlways, Between(0, 5)]
        public int SomeOtherProperty { get; set; }      
 
        [Requires("Property1, Property2")]
        public void OperationX()
        {
        }
    }
