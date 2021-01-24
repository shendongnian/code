c#
public class SomeServiceThing<T> : Singleton<SomeServiceThing<T>>
{
    private Queue<SomeType<T>> pendingEvents = new Queue<SomeType<T>>();
    private void EnqueueEvent(SomeType<T> _event)
    {
        pendingEvents.Enqueue(_event);
        lastEventQueued = DateTime.Now;
    }
    private void Update()
    {
        if (someConditionIsMet)
        {
            // flush the queue and perform an operation with each pending event
        }
    }
}
