    public bool? IsInSecurityGroup
        {
            get
            {
                if (_isInsecurityGroup == false)
                {
                        string GroupName ="GroupName";
                        System.Security.Principal.WindowsIdentity MyIdentity = 
                        System.Security.Principal.WindowsIdentity.GetCurrent();
                        System.Security.Principal.WindowsPrincipal MyPrincipal = new 
                        System.Security.Principal.WindowsPrincipal(MyIdentity);
                        _isInsecurityGroup = (MyPrincipal.IsInRole(GroupName)) ? true : 
                        false;
                }
                return _isInsecurityGroup;
            }
        }
