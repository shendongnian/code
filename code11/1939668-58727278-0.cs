        public bool On
        {
            get; set;
        } = false;
        public override void Read(double voltage, bool trip)
        {
            double P;
            Voltage = voltage;
            this.trip= trip;
            if ((voltage <= 2 || voltage >= 10))
            {
                   On = false;
            }
            else 
            {
                   On = true;
            }....
       public string getText()
        {
            if (On)
                return AveragePressure.ToString("0.0E-0");
            else
                return "Off";
        }
