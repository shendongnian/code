    class UserPermission : IPermission<User>
    {
        public UserPermission(CustomerPermissionType type)
        {
            // Store the type
        }
    }
    class ChannelPermission : IPermission<Channel>
    {
        public ChannelPermission (ChannelPermissionType type)
        {
            // Store the type
        }
    }
