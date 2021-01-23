        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public void SetIdentity() {
            ServiceSecurityContext securityContext = ServiceSecurityContext.Current;
            if (securityContext != null && securityContext.WindowsIdentity != null) {
                Console.WriteLine("Identity's Username: "+securityContext.WindowsIdentity.Name);
            }
        }
