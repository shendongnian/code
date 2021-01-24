    public static string ToCsharpString<TKey,TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items) {
        StringBuilder str = new StringBuilder();
        string type_name = items.GetType().Name;
        int index = type_name.LastIndexOf('`');
        if (index == -1) {
            index = type_name.Length;
        }
        str.Append(type_name, 0, index);
        str.AppendFormat("<{0}, {1}>", typeof(TKey).Name, typeof(TValue).Name);
        str.Append(" {\n");
        foreach (var item in items) {
            str.AppendFormat("\t{{ {0}, {1} }},\n", ToLiteral(item.Key), ToLiteral(item.Value));
        }
        str.Append("}");
        return str.ToString(); 
    }
    static string ToLiteral(object obj) {
        string input = obj as string;
        if (input == null)
            return obj.ToString();
        // https://stackoverflow.com/a/324812/79125
        using (var writer = new StringWriter()) {
            using (var provider = CodeDomProvider.CreateProvider("CSharp")) {
                provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                return writer.ToString();
            }
        }
    }
