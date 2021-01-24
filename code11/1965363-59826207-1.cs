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
-----------------
If the only difference between the different types of `ScheduleItem` is the `EventManager` method which is called, you could do something like this instead of having separate `IntScheduleEvent`, `BoolScheduleEvent`, etc, classes:
public class ScheduleItem<T> : ScheduleItem
{
    private readonly T data;
    private readonly Action<T> activator;
    public ScheduleItem(string eventName, int scheduledStep, int data, Action<T> activator)
        : base(eventName, int scheduledStep)
    {
        this.data = data;
        this.activator = activator;
    }
    public override void Activate()
    {
        activator(data);
    }
}
...
public void AddScheduleItem(int steps, string eventName, int param) {
    schedule.Enqueue(new ScheduleItem<int>(eventName, steps, param, EventManager.TriggerIntEvent), steps);
}
----------
You could even take it one step further and do away with the class hierarchy at all:
public class ScheduleItem
{
    public string EventName { get; }
    public int ScheduledStep { get; }
    private readonly Action activator;
    protected ScheculeItem(string eventName, int scheduledStep, Action activator)
    {
        EventName = eventName;
        ScheduledStep = scheduledStep;
        this.activator = activator;
    }
    public void Activate() => activator();
}
...
public void AddScheduleItem(int steps, string eventName, int param) {
    schedule.Enqueue(new ScheduleItem(eventName, steps, () => EventManager.TriggerIntEvent(param)), steps);
