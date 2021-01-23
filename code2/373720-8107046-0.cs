    public class PropertyWatcher<TSource>
    {
        // initialization code omitted
        private Dictionary<string, object> previousValues;
        private Dictionary<string, Func<TSource, object>> selectors; 
   
        public void RegisterWatcher<TSource>(Func<TSource, object> propertySelector, 
            string propertyName)
        {
            this.selectors.Add(propertyName, propertySelector);
            this.previousValues.Add(propertyName, null);
        }
        public void NotifyIfDifferent<TObject, TPropertyType>(TSource currentItem)
        {
            foreach (var key in this.selectors.Keys)
            {
                var selector = this.selectors[key];
                var currentValue = selector(currentItem);
                if (!currentValue.Equals(this.previousValues[key]))
                {
                    // raise notification, event; antyhing to your liking
                }
                this.previousValues[key] = currentValue;
            }
        }
    }
