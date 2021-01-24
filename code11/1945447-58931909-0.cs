    [BsonNoId]    
    public class DerivedWithId : BaseWithoutId
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
