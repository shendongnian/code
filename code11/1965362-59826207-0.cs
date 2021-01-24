public abstract class ScheduleItem
{
    public string EventName { get; }
    public int ScheduledStep { get; }
    protected ScheculeItem(string eventName, int scheduledStep)
    {
        EventName = eventName;
        ScheduledStep = scheduledStep;
    }
    public abstract void Activate();
}
public class IntScheduleItem
{
    private readonly int data;
    public IntScheduleItem(string eventName, int scheduledStep, int data)
        : base(eventName, int scheduledStep)
    {
        this.data = data;
    }
    public override void Activate()
    {
         EventManager.TriggerIntEvent(EventName, data);
    }
}
... and so on
