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
                _blings[i](this, EventArgs.Empty);
            }
        }
    }
    private static void Main()
    {
        ReverseBling bling = new ReverseBling();
        bling.Bling += delegate { Console.WriteLine(0);};
        bling.Bling += delegate { Console.WriteLine(1); };
        bling.Bling += delegate { Console.WriteLine(2); };
        bling.RaiseBling();
    }
