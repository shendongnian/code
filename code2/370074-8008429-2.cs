    public class CampaignWithStatus
    {
        public Campaign Campaign { get; set; }
        public CampaignStatus Status { get; set; }
    }
    public static IQueryable<CampaignWithStatus> 
        WithContractCount(this IQueryable<Compaign> campaigns)
    {
        return
            from campaign in campaigns
            select new CampaignWithStatus
            {
                Campaign = compaign,
                Status = new CampaignWithStatus
                {
                    Campaign = campaign.Id,
                    ContractCount = compaign.Contracts.Count()
                }
            };
    }
