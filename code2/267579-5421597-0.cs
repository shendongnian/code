        public static string PrettyPrint(this INode code, LanguageProperties language)
        {
            if (code == null) return string.Empty;
            IOutputAstVisitor csOutVisitor = CreateCodePrinter(language);
            code.AcceptVisitor(csOutVisitor, null);
            return csOutVisitor.Text;
        }
        private static IOutputAstVisitor CreateCodePrinter(LanguageProperties language)
        {
            if (language == LanguageProperties.CSharp) return new CSharpOutputVisitor();
            if (language == LanguageProperties.VBNet) return new VBNetOutputVisitor();
            return null;
        }
        public static string ToCSharpCode(this INode code)
        {
            return code.PrettyPrint(LanguageProperties.CSharp);
        }
