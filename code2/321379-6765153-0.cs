    public sealed class ExtendedUser  
    {
        public ExtendedUser(BLL.DTO.User legacyUser)
        {
            this.LegacyUser = legacyUser;
        }
    
        public BLL.DTO.User LegacyUser 
        { 
            get; 
            private set; 
        }
    } 
