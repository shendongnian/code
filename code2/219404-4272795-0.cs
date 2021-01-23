    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExpandCharClass(@"[\-a-zA-F1]"));
            // -abcdefghijklmnopqrstuvwxyzABCDEF1
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            Console.WriteLine();
        }
        // RegexParser stuff
        static ConstructorInfo RegexParser_Ctor;
        static MethodInfo RegexParser_SetPattern;
        static MethodInfo RegexParser_ScanCharClass;
        // RegexCharClass stuff
        static MethodInfo RegexCharClass_RangeCount;
        static MethodInfo RegexCharClass_GetRangeAt;
        static FieldInfo SingleRange_first;
        static FieldInfo SingleRange_last;
        static Program()
        {
            var regexParserType = Assembly.GetAssembly(typeof(Regex))
                                          .GetTypes()
                                          .Where(t => t.Name == "RegexParser")
                                          .Single();
            var regexCharClassType = Assembly.GetAssembly(typeof(Regex))
                                             .GetTypes()
                                             .Where(t => t.Name == "RegexCharClass")
                                             .Single();
            var regexCharClassSingleRangeType = Assembly.GetAssembly(typeof(Regex))
                                                        .GetTypes()
                                                        .Where(t => t.Name == "SingleRange")
                                                        .Single();
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            RegexParser_Ctor = regexParserType.GetConstructor(flags, null, new[] { typeof(CultureInfo) }, null);
            RegexParser_SetPattern = regexParserType.GetMethod("SetPattern", flags, null, new[] { typeof(String) }, null);
            RegexParser_ScanCharClass = regexParserType.GetMethod("ScanCharClass", flags, null, new[] { typeof(Boolean) }, null);
            RegexCharClass_RangeCount = regexCharClassType.GetMethod("RangeCount", flags, null, new Type[] { }, null);
            RegexCharClass_GetRangeAt = regexCharClassType.GetMethod("GetRangeAt", flags, null, new[] { typeof(Int32) }, null);
            SingleRange_first = regexCharClassSingleRangeType.GetField("_first", flags);
            SingleRange_last = regexCharClassSingleRangeType.GetField("_last", flags);
        }
        static string ExpandCharClass(string charClass)
        {
            var regexParser = RegexParser_Ctor.Invoke(new object[] { CultureInfo.CurrentCulture });
            RegexParser_SetPattern.Invoke(regexParser, new object[] { charClass });
            var regexCharClass = RegexParser_ScanCharClass.Invoke(regexParser, new object[] { false });
            int count = (int)RegexCharClass_RangeCount.Invoke(regexCharClass, new object[] { });
            List<string> ranges = new List<string>();
            for (int i = 1; i < count; i++)
            {
                var range = RegexCharClass_GetRangeAt.Invoke(regexCharClass, new object[] { i });
                ranges.Add(RangeToString(range));
            }
            return String.Concat(ranges);
        }
        static string RangeToString(object range)
        {
            char first = (char)SingleRange_first.GetValue(range);
            char last = (char)SingleRange_last.GetValue(range);
            return String.Concat(Enumerable.Range(first, last - first + 1).Select(i => (char)i));
        }
    }
