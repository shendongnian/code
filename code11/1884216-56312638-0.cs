    var compiler = new SqlServerCompiler();
    var query = new Query("Countries");
    List<Group> groups = new List<Group>
    {
        new Group
        {
            Conditions = new List<Condition>
            {
                new Condition {Field = "Group1Field1", Operator = "=", Value="Group1Value1"},
                new Condition {Field = "Group1Field2", Operator = ">", Value="Group1Value2"},
                new Condition {Field = "Group1Field3", Operator = "<", Value="Group1Value3"},
                new Condition {Field = "Group1Field4", Operator = "=", Value="Group1Value4"}
            }
        },
        new Group
        {
            Conditions = new List<Condition>
            {
                new Condition {Field = "Group2Field1", Operator = "=", Value="Group2Value1"},
                new Condition {Field = "Group2Field2", Operator = ">=", Value="Group2Value2"},
                new Condition {Field = "Group2Field3", Operator = "<=", Value="Group2Value3"}
            }
        }
    };
    foreach (Group group in groups)
        foreach (Condition c in group.Conditions)
            query.OrWhere(c.Field, c.Operator, c.Value);
    SqlResult result = compiler.Compile(query);
    string sql = result.Sql;
    Console.WriteLine(sql);
