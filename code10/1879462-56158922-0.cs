    public static class TagTranslator {
        public static string Replace(this string s, Regex re, string news) => re.Replace(s, news);
        public static string Surround(this string src, string beforeandafter) => $"{beforeandafter}{src}{beforeandafter}";
        public static string SurroundIfMissing(this string src, string beforeandafter) => (src.StartsWith(beforeandafter) && src.EndsWith(beforeandafter)) ? src : src.Surround(beforeandafter);
    
        public static string Translate(string q) {
            var projectFields = new[] { "ID", "ProjectName", "ProjectTags" }.ToHashSet();
    
            var opREStr = @"(?<op>==|!=|<>|<=|>=|<|>)";
            var revOps = new[] {
                new { Fwd = "==", Rev = "==" },
                new { Fwd = "!=", Rev = "!=" },
                new { Fwd = "<>", Rev = "<>" },
                new { Fwd = "<=", Rev = ">=" },
                new { Fwd = ">=", Rev = "<=" },
                new { Fwd = "<", Rev = ">" },
                new { Fwd = ">", Rev = "<" }
            }.ToDictionary(p => p.Fwd, p => p.Rev);
    
            var openRE = new Regex(@"^\[", RegexOptions.Compiled);
            var closeRE = new Regex(@"\]$", RegexOptions.Compiled);
    
            var termREStr = @"""[^""]+""|(?:\w|\.)+|\[[^]]+\]";
            var term1REStr = $"(?<term1>{termREStr})";
            var term2REStr = $"(?<term2>{termREStr})";
            var wsREStr = @"\s?";
            var exprRE = new Regex($"{term1REStr}{wsREStr}{opREStr}{wsREStr}{term2REStr}", RegexOptions.Compiled);
    
            var tq = exprRE.Replace(q, m => {
                var term1 = m.Groups["term1"].Captures[0].Value.Replace(openRE, "").Replace(closeRE, "");
                var term1q = term1.SurroundIfMissing("\"");
                var term2 = m.Groups["term2"].Captures[0].Value.Replace(openRE, "").Replace(closeRE, "");
                var term2q = term2.SurroundIfMissing("\"");
                var op = m.Groups["op"].Captures[0].Value;
                if (!projectFields.Contains(term1) && !term1.StartsWith("\"")) { // term1 is Name, term2 is Value
                    return $"ProjectTags.Any(Name == {term1q} && Value {op} {term2})";
                }
                else if (!projectFields.Contains(term2) && !term2.StartsWith("\"")) { // term2 is Name, term1 is Value
                    return $"ProjectTags.Any(Name == {term2q} && Value {revOps[op]} {term1})";
                }
                else
                    return m.Value;
            });
            return tq;
        }
    }
