    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            /// ... whatever
            Map(x => x.IsMarked).Formula("(select count(*) from ItemWithUserFlag where ItemWithUserFlag.ItemId = ItemId and ItemWithUserFlag.UserId = :UserFilter.userId)");
        }
    }
    public class UserFilter : FilterDefinition
    {
        public UserFilter()
        {
            WithName("UserFilter")
                .AddParameter("userId", NHibernate.NHibernateUtil.Int32);
        }
    }
