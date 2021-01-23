    public IDictionary<string, string> ValidateForDeletion(Account ac)
    {
    	var account = _accountRepository.GetPkRk(ac.PartitionKey, ac.RowKey);
    	if (account == null)
    	{
    		_errors.Add("", "Account does not exist");
    	}
    	else if (_productRepository.GetPk("0000" + ac.RowKey).Count() != 0)
    	{
    		_errors.Add("", "Account contains products");
    	}
    	return _errors;
    }
