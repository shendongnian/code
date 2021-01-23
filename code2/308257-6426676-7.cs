        class Car : IRuntime, INetwork
        {
            private string _model = string.Empty;
            private int _engineSize = 0;
            private PointF _location = new PointF();
            private double _distanceAwayFromYou = 0; 
            private double _runtimeSpeed = 0;
            private double _networkSpeed = 0;
            public string Model
            {
                get
                {
                    return _model;
                }
                set
                {
                    if (_model != value)
                    {
                        _model = value;
                    }
                }
            }
            public int EngineSize
            {
                get
                {
                    return _engineSize;
                }
                set
                {
                    if (_engineSize != value)
                    {
                        _engineSize = value;
                    }
                }
            }
            PointF IRuntime.Location
            {
                get
                {
                    return _location;
                }
                set
                {
                    if (_location != value)
                    {
                        _location = value;
                    }
                }
            }
            double INetwork.DistanceAwayFromYou
            {
                get
                {
                    return _distanceAwayFromYou;
                }
                set
                {
                    if (_distanceAwayFromYou != value)
                    {
                        _distanceAwayFromYou = value;
                    }
                }
            }
            double IRuntime.Speed
            {
                get
                {
                    return _runtimeSpeed;
                }
                set
                {
                    if (_runtimeSpeed != value)
                    {
                        _runtimeSpeed = value;
                    }
                }
            }
            double INetwork.Speed
            {
                get
                {
                    return _networkSpeed;
                }
                set
                {
                    if (_networkSpeed != value)
                    {
                        _networkSpeed = value;
                    }
                }
            }
        }
