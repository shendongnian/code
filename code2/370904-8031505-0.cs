     private static string SetProperHTML(string sHtml)
        {
            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);
            string input = sHtml;
            var test = new HtmlAgilityPack.HtmlDocument();
            test.LoadHtml(input);
            test.OptionOutputAsXml = false;
            test.OptionCheckSyntax = true;
            test.OptionFixNestedTags = true;
            test.OptionAutoCloseOnEnd = true;
            test.OptionWriteEmptyNodes = true;
            test.Save(stringWriter);
            Console.WriteLine(sb.ToString());
            return WebUtility.HtmlEncode(sb.ToString().Replace(Environment.NewLine, ""));
        }
