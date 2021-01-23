    class PermissionVerifier {
        public void ExecuteIfHasPermission(Permission perm, Action action) {
            if (GetCurrentUser().HasPermission(perm)) // assumes singleton-like
                                                      // access or injected user
                action();
            throw CreatePermissionException(perm);
        }
    }
    class A {
        // make it obvious what permissions are required for execution
        [RequiresPermission(Permissions.CanExecuteClassAMethod1)]
        public virtual void Method1() {
            //...
        }
    }    
    class AProxy: A {
        private PermissionVerifier verifier;
    
        public override void Method1() {
            ExecuteIfHasPermission(
                GetCurrentMethodRequiresPermissionAttribute(), // reflection
                () => base.Method1());
        }
        private ExecuteIfHasPermission(Permission perm, Action action) {
            verifier.ExecuteIfHasPermission(perm, action);
        }
    }
