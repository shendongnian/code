    class AppointmentDto {
        public long Id { get; set; }
        public string FullName { get; set; }
        public StoreDto Store { get; set; }
    }
    
    class StoreDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
