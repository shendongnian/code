    public class Foo 
    {
        private List<Bar> _barList;
        public List<Bar> BarList 
        {
            get
            {
                return this._barList ?? (this._barList = new List<Bar>());
            }
        }
    }
