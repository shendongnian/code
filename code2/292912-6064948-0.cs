    public interface ICommunityRepository
    {
        ICommunity GetByEmailAddress(string address);
    }
    public class ManageProviderCommunityRepository
        : ICommunityRepository
    {
        public ICommunity GetByEmailAddress(string address)
        {
            var id = new UserIden { Email = address };
            return ManageProvider.GetProxy<ICommunity>(id);
        }
    }
