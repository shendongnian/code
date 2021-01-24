    public class SettingColumn : ObservableObject
    {
        public int _PhaseNumber;
        public int PhaseNumber
        {
            get { return _PhaseNumber; }
            set
            {
                PhaseNumber = value;
                RaisePropertyChangedEvent("PhaseNumber");
            }
        }
        public object _MinPhaseDuration;
        public object MinPhaseDuration
        {
            get { return _Value; }
            set
            {
                Value = value;
                RaisePropertyChangedEvent("Value");
            }
        }
        public string _MinSupplyAirTemp;
        public string MinSupplyAirTemp
        {
            get { return _MinSupplyAirTemp; }
            set
            {
                MinSupplyAirTemp = value;
                RaisePropertyChangedEvent("MinSupplyAirTemp");
            }
        }
        // The rest of your row labels here.
        .
        .
        .
