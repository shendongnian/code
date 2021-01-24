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
            List<DataRow> results;
            while (true)
            {
                results = bigDataTable.AsEnumerable().Skip(pageSize * page++).Take(pageSize).ToList();
                if (!results.Any())
                    break;
                smallTable = results.CopyToDataTable();
                splitedTables.Add(smallTable);
                Thread.Sleep(1000 * 60 * 1);
            } while (results.Any());
        }
