    public class EmployeeViewModel
        {
            [BsonId((IdGenerator=typeof(StringObjectIdGenerator))]
            public Guid ownerId { get; set; }
            [BsonElement("personalData")]
            public PersonalDataViewModel personalData { get; set; }
            [BsonElement("address")]
            public AddressViewModel address { get; set; }
    }
