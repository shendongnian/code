    public class IndicatorCollection
    {
        public void AddIndicator(string className)
        {
            _collection.Add(Activator.CreateInstance(null, className));
        }
    
        private List<Indicator> _collection = new List<Indicator>();
    }
