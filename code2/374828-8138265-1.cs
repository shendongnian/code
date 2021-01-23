    public class QueryRow {
        private readonly IDictionary<string,object> values;
        internal QueryRow(IDictionary<string,object> values) {
            this.values = values;
        }
        public object this[string key] {
            get { return values[key]; }
            set { values[key] = value; }
        }
    }
