    public class InfoTable
        {
            Dictionary<string, int> _collection;
            public InfoTable()
            {
                _collection = new Dictionary<string,int>();
            }
             
            public int this[string col,string row] {
    
                get
                {
                    string colrow = col+"_"+row;
                    if (_collection.ContainsKey(colrow))
                        return _collection[colrow];
                    _collection.Add(colrow, 0);
                    return 0;
                }
                set
                {
                    string colrow = col + "_" + row;
                    if (_collection.ContainsKey(colrow))
                        _collection[colrow] = value;
                    else
                        _collection.Add(colrow, value);
                }
            }
        }
