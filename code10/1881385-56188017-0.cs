    public static Func<Foo, string> GetExpression(string query_string)
    {
        (string format_string, List<string> prop_names) = QueryStringToFormatString(query_string);
        
        var lambda_parameter = Expression.Parameter(typeof(Foo));
        Expression[] formatting_params = prop_names.Select(
            p => Expression.MakeMemberAccess(lambda_parameter, typeof(Foo).GetProperty(p))
         ).ToArray();
        var formatMethod = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object[]) });
        var format_call = Expression.Call(formatMethod, Expression.Constant(format_string), Expression.NewArrayInit(typeof(object), formatting_params));
        var lambda = Expression.Lambda(format_call, lambda_parameter) as Expression<Func<Foo, string>>;
        return lambda.Compile();
    }
    // A *very* primitive parser, improve as needed
    private static (string format_string, List<string> ordered_prop_names) QueryStringToFormatString(string query_string)
    {
        List<string> prop_names = new List<string>();
        string format_string = Regex.Replace(query_string, @"\[.+?\]", m => {
            string prop_name = m.Value.Substring(1, m.Value.Length - 2);
            var known_pos = prop_names.IndexOf(prop_name);
            if (known_pos < 0)
            {
                prop_names.Add(prop_name);
                known_pos = prop_names.Count - 1;
            }
            return $"{{{known_pos}}}";
        });
        return (format_string, prop_names);
    }
