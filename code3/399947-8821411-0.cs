    public class Column<T> where T : IPrivateObject
    {
        private readonly string _name;
        private readonly Func<T, object> _valueGetter;
        /// <summary>
        /// Gets the column name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
                
        /// <summary>
        /// Gets the value of this column from the
        /// specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public object GetValueFrom(T obj)
        {
            return _valueGetter(obj);
        }
        public Column(string columnName, Func<T, object> valueGetter)
        {
            _name = columnName;
            _valueGetter = valueGetter;
        }
    }
