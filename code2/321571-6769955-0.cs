    public class Arbiter<T>
    {
        private static Random _rnd = new Random();
        private HashSet<T> _all = new HashSet<T>();
        private HashSet<T> _available = new HashSet<T>();        
        private object lockObj = new object();
        private uint _modCnt = 0;
        public void Add(T item)
        {
            lock (lockObj)
            {
                _all.Add(item);
                _available.Add(item);
                _modCnt++;
            }
        }
        public bool Remove(T item)
        {
            lock (lockObj)
            {
                if (_available.Contains(item))
                {
                    _available.Remove(item);
                    _all.Remove(item);
                    _modCnt++;
                    return true;
                }
                else if (!_all.Contains(item))
                    return false;
                throw new InUseException();            
            }
        }
        private bool CheckOut(T item) 
        {
            lock (lockObj)
            {
                return _available.Remove(item);
            }
        }
        private void CheckIn(T item) 
        {
            lock (lockObj)
            {
                _available.Add(item);
            }
        }
        public IEnumerable<T> getEnumerable()
        {
            LinkedList<T> visited = new LinkedList<T>();
            LinkedList<T> all;
            uint modCnt;
            lock (lockObj)
            {
                //a list of all our items, in random order
                //each enumeration will get a new random order
                //should minimize collisions 
                all = new LinkedList<T>(_all.OrderBy(x => _rnd.Next()));
                modCnt = _modCnt;
            }
            while (all.Count > 0) 
            {
                if (modCnt != _modCnt)
                {//items have been added or removed ...
                    modCnt = _modCnt;
                    T[] r;
                    T[] a;
                    lock (lockObj)
                    {
                        r = all.Except(_all).ToArray();//items we want to remove
                        a = _all.Except(all.Concat(visited)).ToArray();//items we want to add
                    }
                    foreach (var item in r)
                        all.Remove(item);
                    foreach (var item in a)
                    {//random placement for minimized collision probability
                        var node = all.First;
                        int skip = _rnd.Next() % all.Count;
                        for (int i = 0; i < skip && node.Next != null; i++)
                            node = node.Next;
                        all.AddAfter(node, item);
                    }
                }
                var current = all.First;
                all.RemoveFirst();
                if (CheckOut(current.Value))
                {//checkout successfull -> we can have the item, and noone else will get it until we give it back
                    yield return current.Value; // hand the item out for processing
                    //note: yield return will _not_ end this method here
                    CheckIn(current.Value); // give the item back so others can get it
                    visited.AddLast(current); // mark as visited
                }
                else 
                {//someone else has our item ... a.k.a. collision
                    all.AddLast(current); // move item to the end of our list to process it later
                    //maybe we should take care of the case if there are no other items left
                    //we could wait a bit before trying again ... but i don't care right now
                }
            }
        }
    }
