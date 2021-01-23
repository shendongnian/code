    namespace System.CodeDom.Compiler
    {
        public class CompilerError
        {
            public string ErrorText;
            public bool IsWarning;
        }
        public class CompilerErrorCollection : List<CompilerError>
        {
        }
    }
