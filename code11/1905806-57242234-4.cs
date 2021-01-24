    public static class DataRowExtensions
    {
        public static object Compute(this DataRow dataRow, string expression)
        {
            using (var clonedDT = CloneDataTable(dataRow))
            {
                clonedDT.ImportRow(dataRow);
                var clonedRow = clonedDT.Rows[0];
                var dataColumn = clonedDT.Columns.Add(null, typeof(object), expression);
                return clonedRow[dataColumn];
            }
        }
        public static T Compute<T>(this DataRow dataRow, string expression)
        {
            using (var clonedDT = CloneDataTable(dataRow))
            {
                clonedDT.ImportRow(dataRow);
                var clonedRow = clonedDT.Rows[0];
                var dataColumn = clonedDT.Columns.Add(null, typeof(T), expression);
                return clonedRow.Field<T>(dataColumn);
            }
        }
        public static T? ComputeNullable<T>(this DataRow dataRow, string expression)
            where T : struct
        {
            using (var clonedDT = CloneDataTable(dataRow))
            {
                clonedDT.ImportRow(dataRow);
                var clonedRow = clonedDT.Rows[0];
                var dataColumn = clonedDT.Columns.Add(null, typeof(T), expression);
                return clonedRow.Field<T?>(dataColumn);
            }
        }
        private static DataTable CloneDataTable(DataRow dataRow)
        {
            var dataTable = dataRow.Table;
            var dataSet = dataRow.Table.DataSet;
            if (dataSet == null) return dataTable.Clone();
            var clonedDT = dataSet.Tables.Add();
            foreach (DataColumn column in dataTable.Columns)
            {
                clonedDT.Columns.Add(column.ColumnName, column.DataType);
            }
            var relationsAdded = new List<
                (DataRelation Cloned, DataRelation Original)>();
            foreach (var relation in dataTable.ParentRelations
                .Cast<DataRelation>().ToArray())
            {
                var relationName = relation.RelationName;
                relation.RelationName = Guid.NewGuid().ToString();
                var clonedColumns = relation.ChildColumns
                    .Select(c => clonedDT.Columns[c.ColumnName]).ToArray();
                var clonedRelation = dataSet.Relations.Add(relationName,
                    relation.ParentColumns, clonedColumns, createConstraints: false);
                relationsAdded.Add((clonedRelation, relation));
            }
            foreach (var relation in dataTable.ChildRelations
                .Cast<DataRelation>().ToArray())
            {
                var relationName = relation.RelationName;
                relation.RelationName = Guid.NewGuid().ToString();
                var clonedColumns = relation.ParentColumns
                    .Select(c => clonedDT.Columns[c.ColumnName]).ToArray();
                var clonedRelation = dataSet.Relations.Add(relationName,
                    clonedColumns, relation.ChildColumns, createConstraints: false);
                relationsAdded.Add((clonedRelation, relation));
            }
            clonedDT.Disposed += (s, e) => // Cleanup
            {
                clonedDT.Rows.Clear();
                foreach (var entry in relationsAdded)
                {
                    dataSet.Relations.Remove(entry.Cloned);
                    entry.Original.RelationName = entry.Cloned.RelationName;
                }
                clonedDT.Columns.Clear();
                dataSet.Tables.Remove(clonedDT);
            };
            return clonedDT;
        }
    }
