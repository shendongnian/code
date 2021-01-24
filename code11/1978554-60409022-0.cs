    public class SomeServiceThing<T>: Singleton<SomeServiceThing>
    {
        private Queue<SomeType<T>> = new Queue<SomeType<T>>();
    ....
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
