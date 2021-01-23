    public class IndicatorCollection
    {
        public void AddIndicator(string className)
        {
            _collection.Add((Indicator)
                Activator.CreateInstance(null, className).Unwrap());
        }
    
        private List<Indicator> _collection = new List<Indicator>();
    }
