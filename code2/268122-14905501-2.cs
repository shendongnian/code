    public class UserRepository : Repository<User>, IUserRepository
        {
            public UserRepository(ISession session)
               : base(session)
            {
            }
    
            public User find_user_by_openid(string openid_claimed)
            {
                return base.FindBy(x => x.Openid == openid_claimed);
            }
    
            public User find_user_by_id(int id)
            {
                return base.FindBy(x => x.Id == id);
            }        
    
        }
