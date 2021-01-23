    public class Visit : IVisit
    {
        /// <summary>
        /// This constructor is required for the JSON deserializer to be able
        /// to identify concrete classes to use when deserializing the interface properties.
        /// </summary>
        public Visit(MyLocation location, Guest guest)
        {
            Location = location;
            Guest = guest;
        }
        public long VisitId { get; set; }
        public ILocation Location { get;  set; }
        public DateTime VisitDate { get; set; }
        public IGuest Guest { get; set; }
    }
