    using System;
    namespace OAuthServerBroker.EF
    {
        [Serializable]
        public partial class ResourceOwner
        {
            public EntityState State { get; set; } //can even put into new properties
        }
    }
