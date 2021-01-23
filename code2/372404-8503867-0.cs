    public class PermissionController
    {
        private readonly string _file;
        private readonly FileSecurity _accessControl;
        private readonly SecurityIdentifier _id;
        private readonly List<FileSystemAccessRule> _permissionsDenied;
        public PermissionController(string file)
        {
            _file = file;
            _accessControl = File.GetAccessControl(_file);
            _id = WindowsIdentity.GetCurrent().Owner;
            _permissionsDenied = new List<FileSystemAccessRule>();
        }
        public void Allow(params FileSystemRights[] rights)
        {
            foreach (var right in rights)
                AddRule(Rule(right, AccessControlType.Allow));
        }
        public void Deny(params FileSystemRights[] rights)
        {
            foreach (var right in rights)
            {
                var rule = Rule(right, AccessControlType.Deny);
                AddRule(rule);
                _permissionsDenied.Add(rule);
            }
        }
        private void AddRule(FileSystemAccessRule rule)
        {
            _accessControl.AddAccessRule(rule);
        }
        private FileSystemAccessRule Rule(FileSystemRights right, AccessControlType type)
        {
            return new FileSystemAccessRule(_id, right, type);
        }
        public void RemoveDeniedPermissions()
        {
            foreach (var rule in _permissionsDenied)
                _accessControl.RemoveAccessRule(rule);
            Apply();
        }
        public void Apply()
        {
            File.SetAccessControl(_file,_accessControl);
        }
    }
