    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public ICollection<Bid> Bids { get; set; }
        [JsonIgnore]
        public ICollection<Post> FreelanceService { get; set; }
    }
