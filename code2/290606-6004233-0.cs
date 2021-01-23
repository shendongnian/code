    static void Main() {
        ExpirationList<string> list = new ExpirationList<string>(new List<string>());
        bool r1 = list.Add("Bob", 3000); // true
        Thread.Sleep(2000);
        bool r2 = list.Add("Bob", 3000); // false
        Thread.Sleep(2000);
        bool r3 = list.Add("Bob", 3000); // true
    }
    public class ExpirationList<T> {
        private List<T> _list;
        public ExpirationList(List<T> list) {
            if (list == null) throw new ArgumentException();
            _list = list;
        }
        public bool Add(T item, int lifetime) {
            lock (_list) {
                if (_list.Contains(item))
                    return false;
                _list.Add(item);
            }
            new Action<int>(time => Thread.Sleep(time))
                .BeginInvoke(lifetime, new AsyncCallback(result => {
                    T obj = (T)result.AsyncState;
                    lock (_list) {
                        _list.Remove(obj);
                    }
                }), item);
            return true;
        }
        // add other proxy code here
    }
