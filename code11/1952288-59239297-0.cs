        private void WorkHere(DataTable _myTable)
        {
            //Work Here
        }
            //Here Your DataTable from SQL
            DataTable _dt = new DataTable();
            int _i = _dt.Rows.Count;
            int _total = _i;
            while (_i > 0)
            {
                int _n = 1000;
                if (_i < 1000)
                {
                    _n = _i;
                }
                DataTable _yourTable = _dt.Rows.Cast<System.Data.DataRow>().Skip(_total - _i).Take(_n).CopyToDataTable();
                new System.Threading.Thread(() =>
                {
                    WorkHere(_yourTable);
                }).Start();
                _i -= _n;
            }
