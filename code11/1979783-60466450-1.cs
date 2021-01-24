    private Bitmap Success
    {
        get
        {
            return new Bitmap(MYAPP.Properties.Resources.successImg);
        }
    }
    
    private Bitmap Failure
    {
        get
        {
            return new Bitmap(MYAPP.Properties.Resources.failureImg);
        }
    }
    
    private void UpdateIcons(IPStatus status)
    {
        if (status == IPStatus.Success)
        {
            pictureBox1.Image = Success;
        }
        else
        {
            pictureBox1.Image = Failure;
        }
    }
    
    private void TryPing()
    {
        var p = PingIt(new object(), "8.8.8.8");
        UpdateIcons(p.Status);
    }
    
    private static PingReply PingIt(object sender, string ip)
    {
        Ping p = new Ping();
        return p.Send(ip);
    }
