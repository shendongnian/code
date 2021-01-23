    Add-Type -typedef @"
    public class MyComputer
    {
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        string _userName;
    
        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }
        string _deviceName;
    }
    "@
    
    New-Object MyComputer | fl *
