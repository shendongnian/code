    public class Product
    {
        [Length(Min=3,Max=255,Message="Oh noes!")]
        public virtual string Name { get; set; }
    }
