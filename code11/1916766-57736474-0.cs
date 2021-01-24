        private List<Bind> _Registers = new List<Bind>();
    private ModbusClient modbusClient;
    private void Form1_Load(object sender, EventArgs e)
    {
        modbusClient = new ModbusClient("10.54.11.252", 502);
        modbusClient.Connect();
        int[] ReadValues = modbusClient.ReadHoldingRegisters(0, 1);
        for(var i = 0; i < ReadValues.length; i++)
        {
          Registers.Add(new Bind()
            {
                Value = ReadValues[i];
            });
        }
        txt40001.DataBindings.Add(new Binding("Text", Registers[0],
         "Value", true, DataSourceUpdateMode.OnPropertyChanged));
    }
    public List<Bind> Registers
    {
        get
        {
            return _Registers;
        }
        set
        {
            _Registers = value;
        }
    }
     
