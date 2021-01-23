        using System.Security.Principal
        private List<string> GetGroups(string userName)
        {
            List<string> result = new List<string>();
            WindowsIdentity wi = new WindowsIdentity(userName);
            foreach (IdentityReference group in wi.Groups)
            {
                try
                {
                    result.Add(group.Translate(typeof(NTAccount)).ToString());
                }
                catch (Exception ex) { }
            }
            result.Sort();
            return result;
        }
