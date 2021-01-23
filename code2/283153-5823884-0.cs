    public class Car 
    {
        public virtual int CarId { get; set; }
        public virtual string TypeName { get; set; }
        // This must be accessible to the mapping 
        public double? PriceData { get; set; } 
    
        public ConvertableNullable<double> Price 
        { 
            get { // Return data from PriceData }
            set { // Set data to PriceData }
        }
    }
