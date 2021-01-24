    private Bitmap _Success;
    private Bitmap Success
    {
        get
        {
            if (_Success == null)
            {
                _Success = new Bitmap(MYAPP.Properties.Resources.success);
            }
    
            return _Success; ;
        }
    }
    
    private Bitmap _Failure;
    private Bitmap Failure
    {
        get
        {
            if (_Failure == null)
            {
                _Failure = new Bitmap(MYAPP.Properties.Resources.falure);
            }
            return _Failure;
        }
    }
    
    // use when there is no need for the bitmaps/form is closed
    private void DisposeBitmaps()
    {
        if (_Success != null)
        {
            _Success.Dispose();
        }
        if (_Failure != null)
        {
            _Failure.Dispose();
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
