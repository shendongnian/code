    public class Restaurant {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public double AverageRating { get; set; }
    }
