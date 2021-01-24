       public DeviceSession DeviceSession
        {
            get => _deviceSession;
            set
            {
                if (_deviceSession != value)
                {
                    SetProperty(ref _deviceSession, value);
                    CallSome();
                }
            }
        }
