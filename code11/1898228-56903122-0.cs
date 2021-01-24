    public class FeatUserDto
    {
        public int FeatUserId { get; set; }
        public string Role { get; set; }
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityId { get; set; }
        public List<ScenarioDto> Scenarios { get; set; }
    }
    public class ScenarioDto
    {
        public int ScenarioId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Active { get; set; }
    }
	
