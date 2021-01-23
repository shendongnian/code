    public class YourClass
    {
        private List<Layer> _layers;
        public List<Layer> Layers
        {
            get
            {
                _layers = _layers.OrderBy(y => y.LayerColor).ThenBy(y => y.Name).ToList();
                return _layers;
            }
            set
            {
                _layers = value;
            }
        }
    }
