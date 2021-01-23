    namespace StyleCop.CustomRules
    {
        [SourceAnalyzer(typeof(CsParser))]
        public class MyCustomRules : SourceAnalyzer
        {
            public override void AnalyzeDocument(CodeDocument document)
            {
                // ...
                // code here can raise CR1001 as well as CR1002
            }
        }
    }
