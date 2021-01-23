        static void Main(string[] args)
        {
            var code = @"#region ClassName.Test()    //Some method that does stuff
                //some stuff
                #endregion
                #region ClassCName.Random()
                public static void Test()
                {
                     //Some more stuff
                }
                #endregion";
            List<string> codeRegions = GetCodeRegions(code);
        }
        private static List<string> GetCodeRegions(string code)
        {
            List<string> codeRegions = new List<string>();
            //Split code into regions
            var matches = Regex.Matches(code, "#region.*?#endregion", RegexOptions.Singleline);
            foreach (var match in matches)
            {
                //split regions into lines
                string[] lines = match.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                if (lines.Length > 2)
                {
                    codeRegions.Add(string.Join("\r\n", lines, 1, lines.Length - 2));
                }
            }
            return codeRegions;
        }
