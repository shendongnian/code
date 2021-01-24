     var leftJoinDataRows = (from dt1 in datatable1.AsEnumerable()
                                    join dt2 in datatable2.AsEnumerable() on dt1.Field<int>("id") equals dt2.Field<int>("id") into leftouter
                                    from dt2 in leftouter.DefaultIfEmpty()
                                    select dt1).ToList();
            var dataTable2Columns = datatable2.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
            var newColumns = datatable1.Columns.Cast<DataColumn>()
                                .Where(x => !dataTable2Columns.Contains(x.ColumnName))
                                 .Select(x => x.ColumnName)
                                .ToArray();
            foreach (var dr in leftJoinDataRows)
            {
                foreach (var column in newColumns)
                {
                    Console.WriteLine(dr[column]);
                }
            }
