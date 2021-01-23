    public static class RegexHelper
    {
        // RegexParser stuff
        static ConstructorInfo RegexParser_Ctor;
        static MethodInfo RegexParser_SetPattern;
        static MethodInfo RegexParser_ScanCharClass;
        // RegexCharClass stuff
        static MethodInfo RegexCharClass_RangeCount;
        static MethodInfo RegexCharClass_GetRangeAt;
        static FieldInfo SingleRange_first;
        static FieldInfo SingleRange_last;
        static RegexHelper()
        {
            var types = Assembly.GetAssembly(typeof(Regex)).GetTypes().ToList();
            var regexParserType = types.Where(t => t.Name == "RegexParser").Single();
            var regexCharClassType = types.Where(t => t.Name == "RegexCharClass").Single();
            var regexCharClassSingleRangeType = types.Where(t => t.Name == "SingleRange").Single();
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            RegexParser_Ctor = regexParserType.GetConstructor(flags, null, new[] { typeof(CultureInfo) }, null);
            RegexParser_SetPattern = regexParserType.GetMethod("SetPattern", flags, null, new[] { typeof(String) }, null);
            RegexParser_ScanCharClass = regexParserType.GetMethod("ScanCharClass", flags, null, new[] { typeof(Boolean) }, null);
            RegexCharClass_RangeCount = regexCharClassType.GetMethod("RangeCount", flags, null, new Type[] { }, null);
            RegexCharClass_GetRangeAt = regexCharClassType.GetMethod("GetRangeAt", flags, null, new[] { typeof(Int32) }, null);
            SingleRange_first = regexCharClassSingleRangeType.GetField("_first", flags);
            SingleRange_last = regexCharClassSingleRangeType.GetField("_last", flags);
        }
        static object RegexParser(CultureInfo culture)
        {
            return RegexParser_Ctor.Invoke(new object[] { culture });
        }
        static void SetPattern(this object regexParser, string pattern)
        {
            RegexParser_SetPattern.Invoke(regexParser, new object[] { pattern });
        }
        static object ScanCharClass(this object regexParser, bool caseInsensitive)
        {
            return RegexParser_ScanCharClass.Invoke(regexParser, new object[] { caseInsensitive });
        }
        static int RangeCount(this object regexCharClass)
        {
            return (int)RegexCharClass_RangeCount.Invoke(regexCharClass, new object[] { });
        }
        static object GetRangeAt(this object regexCharClass, int i)
        {
            return RegexCharClass_GetRangeAt.Invoke(regexCharClass, new object[] { i });
        }
        static char Range_first(this object singleRange)
        {
            return (char)SingleRange_first.GetValue(singleRange);
        }
        static char Range_last(this object singleRange)
        {
            return (char)SingleRange_last.GetValue(singleRange);
        }
        public static string ExpandCharClass(string charClass)
        {
            var regexParser = RegexHelper.RegexParser(CultureInfo.CurrentCulture);
            regexParser.SetPattern(charClass);
            var regexCharClass = regexParser.ScanCharClass(false);
            int count = regexCharClass.RangeCount();
            List<string> ranges = new List<string>();
            // range 0 can be skipped
            for (int i = 1; i < count; i++)
            {
                var range = regexCharClass.GetRangeAt(i);
                ranges.Add(RangeToString(range));
            }
            return String.Concat(ranges);
        }
        static string RangeToString(object range)
        {
            char first = range.Range_first();
            char last = range.Range_last();
            return String.Concat(Enumerable.Range(first, last - first + 1).Select(i => (char)i));
        }
    }
    // usage:
    RegexHelper.ExpandCharClass(@"[\-a-zA-F1 5-9]");
    // "-abcdefghijklmnopqrstuvwxyzABCDEF1 56789"
