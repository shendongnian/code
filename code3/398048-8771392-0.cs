    public class CampaignContext :  DbContext
    {
        public DbSet<CmsContent> Contents { get; set; }
        public DbSet<CmsCategoryType> CategoryTypes { get; set; }
    }
