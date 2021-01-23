    public class HistoGrapher
    {
        public HistoGrapher(IList<string> points, IList<T> values)
        {
            Contract.Requires<ArgumentNullException>(points != null, "points");
            Contract.Requires<ArgumentNullException>(values != null, "values");
            Contract.Requires<ArgumentException>(points.Count == values.Count, "The lengths of the lists should be equal.");
            var pointValuePairs = points.Select((point, pointIndex) => new KeyValuePair<string, T>(point, values[pointIndex]))
            Init(pointValuePairs);
        }
        public HistoGrapher(IEnumerable<KeyValuePair<string, T>> pointValuePairs)
        {
            Init(pointValuePairs);
        }
        private void Init(IEnumerable<KeyValuePair<string, T>> pointValuePairs)
        {
             // useful code goes here
        }
    }
