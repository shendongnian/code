    public static class RegexHelper
    {
        public static string ExpandCharClass(string charClass)
        {
            var regexParser = new RegexParser(CultureInfo.CurrentCulture);
            regexParser.SetPattern(charClass);
            var regexCharClass = regexParser.ScanCharClass(false);
            int count = regexCharClass.RangeCount();
            List<string> ranges = new List<string>();
            // range 0 can be skipped
            for (int i = 1; i < count; i++)
            {
                var range = regexCharClass.GetRangeAt(i);
                ranges.Add(ExpandRange(range));
            }
            return String.Concat(ranges);
        }
        static string ExpandRange(SingleRange range)
        {
            char first = range._first;
            char last = range._last;
            return String.Concat(Enumerable.Range(first, last - first + 1).Select(i => (char)i));
        }
        internal class RegexParser
        {
            static readonly Type RegexParserType;
            static readonly ConstructorInfo RegexParser_Ctor;
            static readonly MethodInfo RegexParser_SetPattern;
            static readonly MethodInfo RegexParser_ScanCharClass;
            static RegexParser()
            {
                RegexParserType = Assembly.GetAssembly(typeof(Regex)).GetType("System.Text.RegularExpressions.RegexParser");
                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                RegexParser_Ctor = RegexParserType.GetConstructor(flags, null, new[] { typeof(CultureInfo) }, null);
                RegexParser_SetPattern = RegexParserType.GetMethod("SetPattern", flags, null, new[] { typeof(String) }, null);
                RegexParser_ScanCharClass = RegexParserType.GetMethod("ScanCharClass", flags, null, new[] { typeof(Boolean) }, null);
            }
            private readonly object instance;
            internal RegexParser(CultureInfo culture)
            {
                instance = RegexParser_Ctor.Invoke(new object[] { culture });
            }
            internal void SetPattern(string pattern)
            {
                RegexParser_SetPattern.Invoke(instance, new object[] { pattern });
            }
            internal RegexCharClass ScanCharClass(bool caseInsensitive)
            {
                return new RegexCharClass(RegexParser_ScanCharClass.Invoke(instance, new object[] { caseInsensitive }));
            }
        }
        internal class RegexCharClass
        {
            static readonly Type RegexCharClassType;
            static readonly MethodInfo RegexCharClass_RangeCount;
            static readonly MethodInfo RegexCharClass_GetRangeAt;
            static RegexCharClass()
            {
                RegexCharClassType = Assembly.GetAssembly(typeof(Regex)).GetType("System.Text.RegularExpressions.RegexCharClass");
                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                RegexCharClass_RangeCount = RegexCharClassType.GetMethod("RangeCount", flags, null, new Type[] { }, null);
                RegexCharClass_GetRangeAt = RegexCharClassType.GetMethod("GetRangeAt", flags, null, new[] { typeof(Int32) }, null);
            }
            private readonly object instance;
            internal RegexCharClass(object regexCharClass)
            {
                if (regexCharClass == null)
                    throw new ArgumentNullException("regexCharClass");
                if (regexCharClass.GetType() != RegexCharClassType)
                    throw new ArgumentException("not an instance of a RegexCharClass object", "regexCharClass");
                instance = regexCharClass;
            }
            internal int RangeCount()
            {
                return (int)RegexCharClass_RangeCount.Invoke(instance, new object[] { });
            }
            internal SingleRange GetRangeAt(int i)
            {
                return new SingleRange(RegexCharClass_GetRangeAt.Invoke(instance, new object[] { i }));
            }
        }
        internal struct SingleRange
        {
            static readonly Type RegexCharClassSingleRangeType;
            static readonly FieldInfo SingleRange_first;
            static readonly FieldInfo SingleRange_last;
            static SingleRange()
            {
                RegexCharClassSingleRangeType = Assembly.GetAssembly(typeof(Regex)).GetType("System.Text.RegularExpressions.RegexCharClass+SingleRange");
                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                SingleRange_first = RegexCharClassSingleRangeType.GetField("_first", flags);
                SingleRange_last = RegexCharClassSingleRangeType.GetField("_last", flags);
            }
            internal char _first;
            internal char _last;
            internal SingleRange(object singleRange)
            {
                if (singleRange == null)
                    throw new ArgumentNullException("singleRange");
                if (singleRange.GetType() != RegexCharClassSingleRangeType)
                    throw new ArgumentException("not an instance of a SingleRange object", "singleRange");
                _first = (char)SingleRange_first.GetValue(singleRange);
                _last = (char)SingleRange_last.GetValue(singleRange);
            }
        }
    }
    // usage:
    RegexHelper.ExpandCharClass(@"[\-a-zA-F1 5-9]");
    // "-abcdefghijklmnopqrstuvwxyzABCDEF1 56789"
