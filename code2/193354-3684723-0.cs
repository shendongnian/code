    public class Reports
    {
        System.Collections.Generic.IDictionary<string,string> queries;
        public string this[string key]
        {
            get
            {
                return this.queries[key];
            }
        }
    }
