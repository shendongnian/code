    using System.Net.NetworkInformation;
    private Ping _Ping = new Ping();
    private PingOptions _PingOptions = new PingOptions(64, true);
    private byte[] _PingID = Encoding.ASCII.GetBytes("MyPingID");
    private _PingResponse = new AutoResetEvent(false);
    public <classname> //Constructor
    {
      _Ping.PingCompleted += new PingCompletedEventHander(PingCompleted);
    }
    public void PingCompleted(object Sender, PingCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            //Status Unknown;
        }
        else if (e.Error != null)
        {
            //Status Error;
        }
        else if (e.Reply.Status == IPStatus.Success)
        {
            // Device Replying
        }
        else
        {
            // Status Unknown
        }
    }
    public void StartPing(string AddressToPing)
    {
      IPAddress ipAddress = IPAddress.Parse(AddressToPing);
      _Ping.SendAsync(ipAddress, 15000, _PingID, _PingOptions, _PingResponse);
    }
