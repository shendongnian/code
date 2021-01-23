    public class OutputterFactory
    {
        public static IAnalogOutputter CreateBatteryAnalogOutputter(Acquisition acq)
        {
            return new BatteryANalogOutputter(acq.Battery);
        }
    }
