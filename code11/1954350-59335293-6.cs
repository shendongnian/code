    class NoDiRadio
    {
        public EnergizerBattery Battery { get; set; }
        public NoDiRadio()
        {
            Battery = new EnergizerBattery(); // creation and binding inside of NoDiRadio
        }
    }
    class EnergizerBattery
    {
        public void Start()
        {
        }        
    }
