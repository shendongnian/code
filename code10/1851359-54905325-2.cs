//Outside of method, top of class
private DateTime? _startTime = null;
private DateTime? _endTime = null;
//In method
 string currentpressure = ((uint)plc.Read("MD220")).ConvertToDouble().ToString();
 bool breachPressure = plcTestpressure > reqTestPressure;
 if (breachPressure && _startTime == null)
 {
    _startTime = DateTime.Now;
 }
 else if(!breachPressure && _startTime != null)
 {
    _endTime = new DateTime();
    var tickCounter = _endTime.Value.Subtract(_startTime.Value).TotalSeconds;
 }
-----------------------------Edit---------------------------------------
> Am I going about it wrong?
It would be considered cleaner if you moved the pressure monitoring logic to a separate class, thus keeping true to the single responsibility principle.
You can do that by implementing a pressure monitoring class that would raise events when the threshold is breached - something along the lines of - 
        public class PressureObserver
        {
            public event EventHandler<double> OnRaisedAboveThreshhold;
            public event EventHandler<double> OnFellBelowThreshhold;
            public double ThresholdPressure{ get; }
            private double _lastMeasured = 0; //Initial Pressure
            public PressureObserver(double thresholdPressure)
            {
                ThresholdPressure = thresholdPressure;
            }
            public void Observe(double plcTestpressure)
            {
                double pressureDelta = plcTestpressure - _lastMeasured;
                if (pressureDelta > 0) //Pressure climbed
                {
                    if(_lastMeasured < ThresholdPressure &&  //Last measurement was below threshold
                        plcTestpressure > ThresholdPressure) //This one is above, cross made
                    {
                        OnRaisedAboveThreshhold?.Invoke(this, plcTestpressure);
                    }
                }
                else if(pressureDelta < 0) //Pressure declined
                {
                    if (_lastMeasured > ThresholdPressure &&  //Last measurement was above threshold
                        plcTestpressure < ThresholdPressure) //This one is below, cross made
                    {
                        OnFellBelowThreshhold?.Invoke(this, plcTestpressure);
                    }
                }
                _lastMeasured = plcTestpressure;
            }
        }
Then in your main class you would have fields
        private PressureObserver _pressureObserver;
        private DateTime _raisedAboveTime;
        private DateTime _fellBelowTime;
        private double _overpressureDuration;
you would define two methods to react to threshold changes
        private void Obs_OnRaisedAboveTreshhold(object sender, double e)
        {
            //Code to do on raised above
            _raisedAboveTime = DateTime.Now;
        }
        private void Obs_OnFellBelowTreshhold(object sender, double e)
        {
            //Code to do on fell below
            _fellBelowTime = DateTime.Now;
            _overpressureDuration = _fellBelowTime.Subtract(_raisedAboveTime).TotalSeconds;
        }
and in the constructor you would subscribe to the observer class
       _pressureObserver = new PressureObserver(60); //replace 60 with threshold
       _pressureObserver.OnRaisedAboveThreshhold += Obs_OnRaisedAboveTreshhold;
       _pressureObserver.OnFellBelowThreshhold += Obs_OnFellBelowTreshhold;
and in your tick timer you would just add
_pressureObserver.Observe(plcTestpressure);
