    var groupkey = new[] {"Age","Country"};
    var gt = table.Rows.Cast<DataRow>().GroupBy(g => new { Key1 = g.Field<string>(columnName1), Key2 = g.Field<string>(columnName2) })
            .Select(g => new GroupSum
            {
                Key1 = g.Key.Key1,
                Key2 = g.Key.Key2,
                Sum = g.Sum(x => x.Field<double>(columnName4))
            }).PropertiesToDataTable<GroupSum>();
