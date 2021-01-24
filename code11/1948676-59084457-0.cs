    public class Order
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        //This sets the relation
        public string IdentityUserId {get; set; }
        [ForeignKey("IdentityUserId ")]
        public IdentityUser IdentityUser { get; set; }
    }
