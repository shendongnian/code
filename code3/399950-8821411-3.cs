    public class Column<T> where T : IPrivateObject
    {
        private readonly string _name;
        private readonly Func<HtmlHelper<Table<T>>, T, string> _valueGetter;
        public string Name
        {
            get { return _name; }
        }
                
        public string Render(HtmlHelper<Table<T>> helper, T obj)
        {
            return _valueGetter(helper, obj);
        }
        private Column(string columnName, Func<T, object> valueGetter)
        {
            _name = columnName;
            _valueGetter = valueGetter;
        }
        public static Column<T> Create<Tprop>
            (string columnName, Expression<Func<T, Tprop>> valueGetter)
        {
            // capture Tprop
            return new Column<T>(
                columnName,
                (helper, val) => helper.DisplayFor<Tprop>(val).ToString()));
        }
    }
