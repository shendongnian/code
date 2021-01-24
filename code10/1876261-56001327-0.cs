async Task Main()
{
	var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);
	var transaction = Transaction.Current;
	await Task.Delay(1000);
	Transaction.Current = transaction;
	Debug.Assert(Transaction.Current != null); // not null
	await Task.Delay(1000);
	
	Debug.Assert(Transaction.Current == null); // is null :/
	using (var innerScope = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
	{
		// Transaction.Current state is kept across async continuations
		Debug.Assert(Transaction.Current != null); // not null
		await Task.Delay(10);
		Debug.Assert(Transaction.Current != null); // not null
		innerScope.Complete();
	}
}
