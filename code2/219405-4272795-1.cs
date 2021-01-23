    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExpandCharClass(@"[\-a-zA-F1 5-9]"));
            // "-abcdefghijklmnopqrstuvwxyzABCDEF1 56789"
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            Console.WriteLine();
        }
        // RegexParser stuff
        static Func<CultureInfo, object> RegexParser_Ctor;
        static Action<object, string> RegexParser_SetPattern;
        static Func<object, bool, object> RegexParser_ScanCharClass;
        // RegexCharClass stuff
        static Func<object, int> RegexCharClass_RangeCount;
        static Func<object, int, object> RegexCharClass_GetRangeAt;
        static Func<object, char> SingleRange_first;
        static Func<object, char> SingleRange_last;
        static Program()
        {
            var types = Assembly.GetAssembly(typeof(Regex)).GetTypes().ToList();
            var regexParserType = types.Where(t => t.Name == "RegexParser").Single();
            var regexCharClassType = types.Where(t => t.Name == "RegexCharClass").Single();
            var regexCharClassSingleRangeType = types.Where(t => t.Name == "SingleRange").Single();
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var ctor = regexParserType.GetConstructor(flags, null, new[] { typeof(CultureInfo) }, null);
            var setPattern = regexParserType.GetMethod("SetPattern", flags, null, new[] { typeof(String) }, null);
            var scanCharClass = regexParserType.GetMethod("ScanCharClass", flags, null, new[] { typeof(Boolean) }, null);
            var rangeCount = regexCharClassType.GetMethod("RangeCount", flags, null, new Type[] { }, null);
            var getRangeAt = regexCharClassType.GetMethod("GetRangeAt", flags, null, new[] { typeof(Int32) }, null);
            var first = regexCharClassSingleRangeType.GetField("_first", flags);
            var last = regexCharClassSingleRangeType.GetField("_last", flags);
            RegexParser_Ctor = culture => ctor.Invoke(new object[] { culture });
            RegexParser_SetPattern = (parser, pattern) => setPattern.Invoke(parser, new object[] { pattern });
            RegexParser_ScanCharClass = (parser, caseInsensitive) => scanCharClass.Invoke(parser, new object[] { caseInsensitive });
            RegexCharClass_RangeCount = charClass => (int)rangeCount.Invoke(charClass, new object[] { });
            RegexCharClass_GetRangeAt = (charClass, i) => getRangeAt.Invoke(charClass, new object[] { i });
            SingleRange_first = range => (char)first.GetValue(range);
            SingleRange_last = range => (char)last.GetValue(range);
        }
        static string ExpandCharClass(string charClass)
        {
            var regexParser = RegexParser_Ctor(CultureInfo.CurrentCulture);
            RegexParser_SetPattern(regexParser, charClass);
            var regexCharClass = RegexParser_ScanCharClass(regexParser, false);
            int count = RegexCharClass_RangeCount(regexCharClass);
            List<string> ranges = new List<string>();
            // seems range 0 can be skipped
            for (int i = 1; i < count; i++)
            {
                var range = RegexCharClass_GetRangeAt(regexCharClass, i);
                ranges.Add(RangeToString(range));
            }
            return String.Concat(ranges);
        }
        static string RangeToString(object range)
        {
            char first = SingleRange_first(range);
            char last = SingleRange_last(range);
            return String.Concat(Enumerable.Range(first, last - first + 1).Select(i => (char)i));
        }
    }
