    public class Guest
    {
        [JsonProperty]
        public Guid GuestId { get; private set; } = Guid.NewGuid();
    }
