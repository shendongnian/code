    IConnection
    {
      ConnectionType ConnectionType { get; }
      IEnumerable<IPort> Ports { get; }
    }
    IPort
    {
      IConnection Connection { get; }
    }
