    var result = JsonConvert.DeserializeObject<getAvailableHotelResponse>(json);
    public class getAvailableHotelResponse
    {
        public int responseId;
        public availableHotel[] availableHotels;
        public int totalFound;
        public string searchId;
    }
    public class availableHotel
    {
        public string processId;
        public string hotelCode;
        public string availabilityStatus;
    }
