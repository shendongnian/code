    public class IndicatorCollection
    {
        var _dictionary = new Dictrionary<string, Indicator>();
    
        public void AddIndicator(string className)
        {
            _dictionary.Add(
                className,
                (Indicator)Activator.CreateInstance(null, className).Unwrap()
            );
        }
    }
