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
