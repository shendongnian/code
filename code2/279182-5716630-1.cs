    public class MyEntity
    {
        public int Id { get; set; }
    
        [ForeignKey("Navigation")]
        public virtual int NavigationFK { get; set; }
    
        public virtual OtherEntity Navigation { get; set; }
    }
