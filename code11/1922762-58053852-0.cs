    public static ModbusServer ser = new ModbusServer();
    void Connect() {
        ser.Port = Convert.ToInt32(Settings.Default.Port);
        if(!ser.IsConnected())
        {
        ser.Listen();
        ser.HoldingRegistersChanged += Ser_HoldingRegistersChanged;
        ModbusClient client = null;
        client = new ModbusClient("IP Address", 502);
        client.Connect();
        }
    }
