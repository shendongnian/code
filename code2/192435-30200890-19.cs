    public class PropertyChangedHandler
    {
        private readonly Action<string> handler;
        private readonly Predicate<string> condition;
        private readonly IEnumerable<string> properties;
 
        public PropertyChangedHandler(Action<string> handler, 
            Predicate<string> condition, IEnumerable<string> properties)
        {
            this.handler = handler;
            this.condition = condition;
            this.properties = properties;
        }
 
        public void Handle(object sender, PropertyChangedEventArgs e)
        {
            string property = e.PropertyName ?? string.Empty;
 
            if (this.Observes(property) && this.ShouldHandle(property))
            {
                handler(property);
            }
        }
 
        private bool ShouldHandle(string property)
        {
            return condition == null ? true : condition(property);
        }
 
        private bool Observes(string property)
        {
            return string.IsNullOrEmpty(property) ? true :
                !properties.Any() ? true : properties.Contains(property);
        }
    }
