    private StatConnector _StatConn;
    private IStatConnectorCharacterDevice _CharDevice;
    
    private Whatever()
    {
      // declare
      _StatConn = new StatConnectorClass();
      _CharDevice = new MyCharDevice();
      // init R, wire up char device
      _StatConn.Init("R");
      _StatConn.SetCharacterOutputDevice(_CharDevice);
    }
