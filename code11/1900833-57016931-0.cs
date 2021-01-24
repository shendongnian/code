`
public class TimerData
{
  private Parameters parameters;
  public TimerData(Parameters pr = null)
  {
    parameters = pr ?? new Parameters(this);
  }
}
public class Parameters
{
  private TimerData timerData;
  public Parameters(TimerData td = null)
  {
    timerData = td ?? new TimerData(this);
  }
}
`
