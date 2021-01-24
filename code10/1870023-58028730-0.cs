    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
...
        public void Test()
        {
            DataTable bigDataTable = GetBigDataTable();
            var splitedTables = new List<DataTable>();
            var smallTable = new DataTable();
            int page = 1;
            int pageSize = 1000;
            IEnumerable<DataRow> results;
            do
            {
                results = bigDataTable.AsEnumerable().Skip(page++).Take(pageSize);
                smallTable.Rows.Add(results);
                splitedTables.Add(smallTable);
                Thread.Sleep(1000);
            } while (results.Any());
        }
