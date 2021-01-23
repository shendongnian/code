    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.IO;
    public class FileAccessRulesHelper
    {
        public void AddWriteRightsToEveryone(string filename)
        {
            // get sid of everyone group
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            // create rule
            FileSystemAccessRule rule = new FileSystemAccessRule(sid, FileSystemRights.Write, AccessControlType.Allow);
            // get ACL of file
            FileSecurity fsecurity = File.GetAccessControl(filename);
            // modify ACL of file
            fsecurity.Add(rule);
            // apply modified ACL to file
            File.SetAccessControl(fileName, fSecurity);
        }
    }
