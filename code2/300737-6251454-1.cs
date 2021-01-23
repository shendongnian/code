    class PermissionDispatcher : IPermissionProvider
    {
        public void RegisterPermissionProvider<TOwner>(IPermissionProvider     permissionProvider)
        {
            // Store it somewhere
        }
        public IPermissionProvider GetPermissionProvider<TOwner>()
        {
            // Look up a permission provider that is registered for the specified type TOwner and return it.
        }
        bool IPermissionProvider.HasPermission<TOwner>(IPermission<TOwner> permission,     TOwner owner, object target)
        {
            IPermissionProvider  permissionProvider = GetPermissionProvider<TOwner>();
            return permissionProvider .HasPermission<TOwner>(permission, owner, target);
        }
    }
