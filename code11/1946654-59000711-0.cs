    // here you should put retrieved member names and their values. Just  for example, currently here exist a couple of args
    var variablesAndValues = new Dictionary<string, object> { ["arg_1"] = 5, ["arg_2"] = 6, ["arg_3"] = 7 };
    // and you should create an execution code looks like this:
    // var arg_1 = value_1;
    // ..
    // var arg_n = value_n;
    // arg_1 + .. + arg_n
    StringBuilder builder = new StringBuilder();
    foreach (var item in variablesAndValues)
    {
        builder.Append("var ").Append(item.Key).Append(" = ").Append(item.Value).AppendLine(";");
    }
    var variablesCount = variablesAndValues.Count;
    foreach (var item in variablesAndValues.Keys)
    {
        builder.Append(item);
        if (--variablesCount > 0)
        {
            builder.Append(" + ");
        }
    }
    var scriptState = CSharpScript.RunAsync(builder.ToString()).Result;
    var result = scriptState.ReturnValue;
