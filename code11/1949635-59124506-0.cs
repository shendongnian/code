cs
public class TransferOptions : ITransferOptions 
{
   public IConnectionInfo Source { get; set; } = new ConnectionInfo();
   public IConnectionInfo Destination { get; set; } = new ConnectionInfo();
}
