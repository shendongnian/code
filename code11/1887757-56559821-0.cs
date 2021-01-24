c#
[DllImport("mpr.dll")]
private static extern int WNetAddConnection2(NetResource netResource,
     string password, string username, int flags);
[DllImport("mpr.dll")]
     private static extern int WNetCancelConnection2(string name, int flags, bool force);
[StructLayout(LayoutKind.Sequential)]
public class NetResource
{
  public ResourceScope Scope;
  public ResourceType ResourceType;
  public ResourceDisplaytype DisplayType;
  public int Usage;
  public string LocalName;
  public string RemoteName;
  public string Comment;
  public string Provider;
}
public enum ResourceScope : int
{
  Connected = 1,
  GlobalNetwork,
  Remembered,
  Recent,
  Context
};
public enum ResourceType : int
{
  Any = 0,
  Disk = 1,
  Print = 2,
  Reserved = 8,
}
public enum ResourceDisplaytype : int
{
  Generic = 0x0,
  Domain = 0x01,
  Server = 0x02,
  Share = 0x03,
  File = 0x04,
  Group = 0x05,
  Network = 0x06,
  Root = 0x07,
  Shareadmin = 0x08,
  Directory = 0x09,
  Tree = 0x0a,
  Ndscontainer = 0x0b
}
void ConnectToNas(string username, string password, string networkName){
     NetworkCredential cred = new NetworkCredential(username, password);
     var netResource = new NetResource
     {
          Scope = ResourceScope.GlobalNetwork,
          ResourceType = ResourceType.Disk,
          DisplayType = ResourceDisplaytype.Share,
          RemoteName = networkName
     };
     var result = WNetAddConnection2(netResource, credentials.Password,userName,0);
     if (result != 0)
     {
          throw new Win32Exception(result, "Error while connection to NAS");
     }
}
For closing the connection:
c#
void CloseConnection(string networkName){
     WNetCancelConnection2(networkName, 0, true);
}
With this way I was able to connect to the NAS and check if it's readable and writeable by writing a file to it, reading it and afterwards deleting it.
