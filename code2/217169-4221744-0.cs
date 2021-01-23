    string fileName = @"C:\Text.txt";
    
    FileSecurity oFSec = File.GetAccessControl(fileName);
    AuthorizationRuleCollection oARC = oFSec.GetAccessRules(true, true, typeof(NTAccount));
    
    foreach (FileSystemAccessRule oFSAR in oARC)
    {
        Console.WriteLine("User : " + oFSAR.IdentityReference.Value);
        Console.WriteLine("Access Control Type : " + oFSAR.AccessControlType.ToString());
        Console.WriteLine("File System Rights : " + oFSAR.FileSystemRights.ToString());
    }
