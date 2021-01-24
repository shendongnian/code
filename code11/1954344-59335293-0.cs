    class NoDiRadio
    {
        public EnergizerBattery Battery { get; set; }
        public NoDiRadio()
        {
            Battery = new EnergizerBattery();
        }
    }
    class EnergizerBattery
    {
        public void Start()
        {
        }        
    }
