        static System.CodeDom.Compiler.CodeDomProvider CSprovider = 
               Microsoft.CSharp.CSharpCodeProvider.CreateProvider("C#");
        public static string QuoteName(string name)
        {
            return CSprovider.CreateEscapedIdentifier(name);
        }
        public static bool IsAReservedWord(string TestWord)
        {
            return QuoteName(TestWord) != TestWord;
        }
