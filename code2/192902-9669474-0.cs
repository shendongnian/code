    public interface ITruthTable<in T1, in T2, in T3, in T4>
    {
        bool GetValue(T1 obj1, T2 obj2, T3 obj3, T4 obj4);
    }
    public static class TruthTable
    {
        private interface IMutableTable
        {
            void AddRow(bool v1, bool v2, bool v3, bool v4, bool result = false);
        }
        
        private sealed class Table<T1, T2, T3, T4>: ITruthTable<T1, T2, T3, T4>, IMutableTable
        {
            private readonly Func<T1, bool> _column1;
            private readonly Func<T2, bool> _column2;
            private readonly Func<T3, bool> _column3;
            private readonly Func<T4, bool> _column4;
            private readonly List<bool[]> _rows = new List<bool[]>();
            private readonly List<bool> _results = new List<bool>();
            private readonly bool _default;
            public Table(Func<T1, bool> column1, Func<T2, bool> column2, Func<T3, bool> column3, Func<T4, bool> column4, bool defaultValue)
            {
                _column1 = column1;
                _column2 = column2;
                _column3 = column3;
                _column4 = column4;
                _default = defaultValue;
            }
            #region IMutableTable<T1,T2,T3,T4> Members
            void IMutableTable.AddRow(bool v1, bool v2, bool v3, bool v4, bool result)
            {
                _rows.Add(new bool[4]);
                var row = _rows[_rows.Count - 1];
                row[0] = v1;
                row[1] = v2;
                row[2] = v3;
                row[3] = v4;
                _results.Add(result);
            }
            #endregion
            #region ITruthTable<T1,T2,T3,T4> Members
            public bool GetValue(T1 obj1, T2 obj2, T3 obj3, T4 obj4)
            {
                var v1 = _column1(obj1);
                var v2 = _column2(obj2);
                var v3 = _column3(obj3);
                var v4 = _column4(obj4);
                for (int i = 0; i < _rows.Count; i++)
                {
                    var row = _rows[i];
                    if ((row[0] == v1) && (row[1] == v2) && (row[2] == v3) && (row[3] == v4))
                        return _results[i];
                }
                return _default;
            }
            #endregion
        }
        public static ITruthTable<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Func<T1, bool> column1, Func<T2, bool> column2, Func<T3, bool> column3, Func<T4, bool> column4, bool defaultValue = false)
        {
            return new Table<T1, T2, T3, T4>(column1, column2, column3, column4, defaultValue);
        }
        public static ITruthTable<T1, T2, T3, T4> Row<T1, T2, T3, T4>(this ITruthTable<T1, T2, T3, T4> table, bool v1, bool v2, bool v3, bool v4, bool result)
        {
            (table as IMutableTable).AddRow(v1, v2, v3, v4, result);
            return table;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var testTable = TruthTable.Create<bool, bool, bool, bool>
                (b => b /*Column description*/ , b => b /* Column 2 */ , b => b, b => b, defaultValue: false)
            .Row(false,                          false,                  false,  false, false)
            .Row(false,                          true,                   false,  true,  true)
            .Row(true,                           true,                   true,   false, false)
            .Row(true,                           false,                  true,   true,  true);
            var result = testTable.GetValue(false, true, false, true);
        }
