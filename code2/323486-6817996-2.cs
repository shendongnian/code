    public class RoleActionAttribute : Attribute, IMetadataAware
    {
        public string UserRole { get; set; }
        public RoleActionAttribute(string Role)
        {
            this.UserRole = Role;
        }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["role"] = UserRole;
        }
    }
