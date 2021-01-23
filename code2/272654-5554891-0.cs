    public class Dispatcher<T> where T : Event {
        public void Notify<X>(X tEvent) {
            if(typeof(tEvent).IsSubclassOf(typeof(Event))
            {
                if (someField is IListener<X, T>) {
                    //this never executes--X is Event regardless of its derived type
                }
            }
        }
    }
