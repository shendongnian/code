    using System.Data
    var Dt1JoinDt2 = from dr1 in dt1.AsEnumerable()
                      join dr2 in dt2.AsEnumerable()
                      on dr1.Field<Int64>(id1) equals dr2.Field<Int64>(id2) into joinDt1AndDt2
                      from leftjoin in joinDt1AndDt2.DefaultIfEmpty()
                      select dtJoinedTable.LoadDataRow(
                       (from dc1 in dt1.Columns.Cast<DataColumn>() select dc1.ColumnName.ToString()).ToArray() // cast to DataColumn, use joinDt1AndDt2
                      .Union((from dc2 in dt2.Columns.Cast<DataColumn> select dc2.ColumnName.ToString()).ToArray())
                      )
