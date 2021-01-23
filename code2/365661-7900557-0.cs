    public class ReverseBling
    {
        private readonly List<EventHandler> _blings = new List<EventHandler>();
        public event EventHandler Bling
        {
            add
            {
                _blings.Add(value);
            }
            remove
            {
                _blings.Remove(value);
            }
        }
        public void RaiseBling()
        {
            for (int i = _blings.Count - 1; i >= 0; i--)
            {
                var bling = _blings[i];
                bling(this, EventArgs.Empty);
            }
        }
    }
