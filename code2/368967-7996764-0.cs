    public class MyManager<T> : where T:MyEventArgs
    {
        private Dictionary<Delegate, EventFilter> m_cSubscriptions;
    
        public void Subscribe<K>(EventHandler<K> _cHandler, EventFilter<K> _cFilter)
        where K:T
        {
            try
            {
                // cannot convert EventHandler<K> to EventHandler<T>
                m_cSubscriptions.Add(_cHandler, _cFilter);
            }
            catch (ArgumentException)
            {
                m_cSubscriptions[_cHandler] = _cFilter;
            }
        }
    }
