        public int ?MessageFrom { get; set; }
        [ForeignKey("MessageFrom")]
        public virtual Apartment ApartmentFrom { get; set; }
        public int ?MessageTo { get; set; }
        [ForeignKey("MessageTo")]
        public virtual Apartment ApartmentTo { get; set; }
