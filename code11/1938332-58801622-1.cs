    public class InvalidOperationExceptionIgnoringWrapper : IContentOperator
    {
        public void Invoke(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
        {
            try
            {
                WrappedOperator.Invoke(processor, oper, operands);
            }
            catch (InvalidOperationException e)
            {
                Console.Error.WriteLine("Caught InvalidOperationException {0} for {1}", e.Message, oper);
            }
        }
        public IContentOperator WrappedOperator { get; set; }
    }
