    public class Asset
    {
        public virtual string Name { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual string Description { get; set; }
        public virtual Department Location { get; set; }
        public Asset(){
           this.Location=  new Department();
        }
    }
