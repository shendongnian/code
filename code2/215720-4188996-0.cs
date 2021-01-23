    public class LinkedList2<T> : LinkedList<T>{
        public T LastOrDefault() {
            return Last.Value;
        }
    }
    ...
    var list = new LinkedList2<int>();
    list.LastOrDefault();
