    public class CampaignWithCount
    {
        public Campaign Campaign { get; set; }
        public int ContractsCount { get; set; }
    }
    public static IQueryable<CampaignWithCount> 
        WithContractCount(this IQueryable<Compaign> campaigns)
    {
        return
            from campaign in campaigns
            select new CampaignWithCount
            {
                Campaign = compaign,
                ContractsCount = compaign.Contracts.Count()  
            };
    }
