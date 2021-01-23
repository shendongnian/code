    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWithDoubleBackslash()
        {
            const string regex1 = "\\\\par\\b";
            TestRegEx(regex1);
        }
        [TestMethod]
        public void TestWithSingleBackslash()
        {
            const string regex2 = "\\\\par\b";
            TestRegEx(regex2);
        }
        private static void TestRegEx(string regex)
        {
            var richText =
                "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil Arial;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}}\\viewkind4\\uc1\\pard\\f0\\fs20 CC: not specified\\f1\\fs17\\par}";
            Match m = Regex.Match(richText, regex, RegexOptions.None);
            var output = Regex.Replace(richText, regex, "", RegexOptions.IgnoreCase);
            Console.WriteLine("BEFORE : [" + richText + "]");
            Console.WriteLine("AFTER  : [" + output + "]");
            Assert.IsTrue(output.Contains("pard"));
            Assert.IsFalse(output.Contains("fs17\\par"));
        }
    }
