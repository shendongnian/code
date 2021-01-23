    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        private class UserMetadata
        {
            [DisplayName("User Id")]
            public long UserId
            {
                get;
                set;
            }
            
            [DisplayName("User Name")]
            public string UserName
            {
                get;
                set;
            }
        }
    }
