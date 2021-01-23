    static void Main(string[] args)
    {
        var replacements = new[] {
            new Tuple<string, string>("a", "6b"), 
            new Tuple<string, string>("b", "6c"), 
            new Tuple<string, string>("c", "6a")
        };
        string str = "adbc";
        var str2 = MultipleReplace(str, replacements);
    }
    static string MultipleReplace(string str, IEnumerable<Tuple<string, string>> replacements) {
        StringBuilder str2 = new StringBuilder();
        for (int i = 0; i < str.Length; i++) {
            bool found = false;
            foreach (var rep in replacements) {
                if (str.Length - i >= rep.Item1.Length && str.Substring(i, rep.Item1.Length) == rep.Item1) {
                    str2.Append(rep.Item2);
                    found = true;
                    break;
                }
            }
            if (!found) {
                str2.Append(str[i]);
            }
        }
        return str2.ToString();
    }
