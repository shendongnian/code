    class Column<TSource>
    {
        pubic int Index {get; set;
        public string Name {get; set;}
        public Func<TSource, object> PropertyValueSelector {get; set;}
        public object GetValue(TSource source)
        {
            return this.PropertyValueSelector(source);
        }
        ... // possible other properties, like: IsVisible, IsSortable, DisplayFormat?
    }
