    public class StringCollectionTransactionProcessor // Horrible name, sorry.
    {
        private readonly ITransactionProcessor _transactionProcessor;
        public StringCollectionTransactionProcessor(ITransactionProcessor transactionProcessor)
        {
            _transactionProcessor = transactionProcessor;
        }
        public IEnumerable<string> ProcessTransactions(IEnumerable<string> inputs)
        {
            foreach (var input in inputs)
            {
                var transaction = ParseTransaction(input);
                var outputCode = _transactionProcessor.ProcessTransaction(transaction);
                var outputLine = $"{input} {outputCode}";
                yield return outputLine;
            }
        }
        private Transaction ParseTransaction(string input)
        {
            // Get the transaction ID and whatever values you need from the string.
        }
    }
