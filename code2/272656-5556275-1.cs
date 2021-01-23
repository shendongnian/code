    public class Dispatcher<T> where T : Event {
        public void Notify<X>(X tEvent) where X : Event {
            foreach (Object l in listeners) {
                foreach (Type t in l.GetType().GetInterfaces()) {
                    Type[] temp = t.GetGenericArguments();
                    if (temp.Count() > 0 && temp[0] == tEvent.GetType()) {
                        MethodInfo mi = t.GetMethod("OnEvent", new Type[] {tEvent.GetType()});
                        mi.Invoke(l, new object[] { tEvent });
                    }
                }
            }
        }
    }
