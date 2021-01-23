    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("OtherObjectsOfA")]
        public virtual ICollection<B> ObjectsOfB { get; set; }
    }
