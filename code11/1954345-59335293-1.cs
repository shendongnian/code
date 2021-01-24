    class DiRadio
    {
        public IBattery Battery { get; set; }
        public DiRadio(IBattery battery)
        {
            Battery = battery;
        }
    }
    interface IBattery
    {
        void Start();
    }
    class EnergizerBattery : IBattery
    {
        public void Start()
        {
        }        
    }
