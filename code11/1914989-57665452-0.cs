    public class LeadOrganization
    {
        public IEnumerable<LeadOrganizationAddress> Addresses { get; set; }
    
        public LeadOrganization(ExampleContext.Data.LeadOrganization dbLeadOrganization)
        {
            Addresses = dbLeadOrganization.LeadOrganizationAddresses.Select(loa => new LeadOrganizationAddress(loa));
        }
    }
