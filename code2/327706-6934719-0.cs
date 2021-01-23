    public static class ListExtensions
    {
       public static void AddDoubleQuoted(this List<string> list, string input)
       {
         input = input.Replace("'", "''");
         list.Add(input);
       }
    }
    List<string> test = new List<string>();
    test.AddDoubleQuoted("test's");
    test.AddDoubleQuoted("test");
    test.AddDoubleQuoted("test's more");
    string s = string.Format("'{0}'", string.Join("','", test));
