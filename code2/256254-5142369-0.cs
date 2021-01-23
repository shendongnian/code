        public static class ConnectionMonitor
        {
            public static event EventHandler IsConnectedChanged;
    
            private static SystemState _connectionState = null,
                //_cellState = null,
                _gprsState = null;
            private static int _connectionCount = 0;
                //_cellCount = 0;
            private static bool _gprs = false;
            private static bool _isConnected = true;
            private static string _phoneCarrier = SystemState.PhoneOperatorName;
            private const int POWER_FLAGS = 0x00000001; // default
            private const string AXIM_WIFI_ADAPTER = "{98C5250D-C29A-4985-AE5F-AFE5367E5006}\\TIACXWLN1";
    
            public static bool IsPhone
            {
                get { return !string.IsNullOrEmpty(_phoneCarrier); }
            }
    
            public static bool IsGPRSConnected
            {
                get { return _gprs; }
            }
    
            public static bool IsConnected
            {
                get { return _isConnected; }
                set
                {
                    if (_isConnected != value)
                    {
                        _isConnected = value;
                        if (IsConnectedChanged != null)
                        {
                            IsConnectedChanged(null, EventArgs.Empty);
                        }
    
                        if (!_isConnected && !IsPhone)
                        {
                            WifiOn();  
                        }
                    }
                }
            }
    
            private static void WifiOn()
            {
                Win32.CEDEVICE_POWER_STATE state = new Win32.CEDEVICE_POWER_STATE();
                if (Win32.GetDevicePower(AXIM_WIFI_ADAPTER, POWER_FLAGS, ref state) == 0)
                {
                    if (state != Win32.CEDEVICE_POWER_STATE.D0)
                    {
                        Win32.DevicePowerNotify(AXIM_WIFI_ADAPTER, Win32.CEDEVICE_POWER_STATE.D4, POWER_FLAGS);
                        Win32.SetDevicePower(AXIM_WIFI_ADAPTER, POWER_FLAGS, Win32.CEDEVICE_POWER_STATE.D0);
                    }
                }
            }
    
            public static void Init()
            {
                if (_connectionState == null)
                {
                    _connectionState = new SystemState(SystemProperty.ConnectionsCount);
                    _connectionCount = SystemState.ConnectionsCount;
                    _connectionState.Changed += new ChangeEventHandler(_state_Changed);
                }
                //if (_cellState == null)
                //{
                //    _cellState = new SystemState(SystemProperty.ConnectionsCellularCount);
                //    _cellCount = SystemState.ConnectionsCellularCount;
                //    _cellState.Changed += new ChangeEventHandler(_state_Changed);
                //}
                if (_gprsState == null)
                {
                    _gprsState = new SystemState(SystemProperty.PhoneGprsCoverage);
                    _gprs = SystemState.PhoneGprsCoverage;
                    _gprsState.Changed += new ChangeEventHandler(_state_Changed);
                }
                IsConnected =  _connectionCount > 0 || _gprs;
            }
    
            private static void _state_Changed(object sender, ChangeEventArgs args)
            {
                //_cellCount = SystemState.ConnectionsCellularCount;
                _connectionCount = SystemState.ConnectionsCount;
                _gprs = SystemState.PhoneGprsCoverage;
                IsConnected = _connectionCount > 0 || _gprs;
            }
    
            public static void Dispose()
            {
                if (_connectionState != null)
                {
                    _connectionState.Changed -= new ChangeEventHandler(_state_Changed);
                    _connectionState.Dispose();
                    _connectionState = null;
                }
                //if (_cellState != null)
                //{
                //    _cellState.Changed -= new ChangeEventHandler(_state_Changed);
                //    _cellState.Dispose();
                //    _cellState = null;
                //}
                if (_gprsState != null)
                {
                    _gprsState.Changed -= new ChangeEventHandler(_state_Changed);
                    _gprsState.Dispose();
                    _gprsState = null;
                }
            }
    }
