    class Program
    {
        static string ReplaceVariables(Dictionary<string, string> replacements, string input)
        {
            return Regex.Replace(input, @"&([\w\d$@#-]+)(\.|(?=&)|$)", m =>
            {
                string replacement = null;
                return replacements.TryGetValue(m.Groups[1].Value, out replacement)
                     ? replacement
                     : m.Groups[0].Value;
            });
        }
        static void Main(string[] args)
        {
            string[] tests = new[]
            {
                "&DEN", "&DENV", "&DEN&DEN",
                "&DEN&DENV", "&DEN.anything",
                "&DEN..anything", "&DEN Foo",
                "&DEN&FOO&DEN"
            };
            var replace = new Dictionary<string, string>
            {
                { "DEN", "28" },
                { "FOO", "42" }
            };
            foreach (var test in tests)
            {
                Console.WriteLine("{0} -> {1}", test, ReplaceVariables(replace, test));
            }
        }
    }
