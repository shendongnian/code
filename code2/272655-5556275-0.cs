    public class Dispatcher<T> where T : Event {
        public void Notify<X>(X tEvent) where X : Event {
            foreach (Object l in listeners) {
                if (l is IListener<X, T>) { //never true
                    (l as IListener<X, T>).OnEvent();
                }
            }
        }
    }
