    var dtResult = dt1.Clone();
    dtResult.TableName = "dtResult";
    var dt2Cloned = dt2.Clone();
    dt2Cloned.PrimaryKey = null;
    dtResult.Merge(dt2Cloned);
    var primaryKeys = dtResult.PrimaryKey.ToList();
    foreach (var col in dt2.PrimaryKey)
    {
        primaryKeys.Add(dtResult.Columns[col.ColumnName]);
    }
    dtResult.PrimaryKey = primaryKeys.ToArray();
