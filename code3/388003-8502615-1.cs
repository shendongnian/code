    public IDictionary<string, string> ValidateForDeletion(Account ac)
    {
      var account = _accountRepository.GetPkRk(ac.PartitionKey, ac.RowKey);
      return BuildErrorsList(account);
    }
    private IDictionary<string, string> BuildErrorsList(Account account)
    {
      if (account == null)
         _errors.Add("", "Account does not exist");
      if (_productRepository.GetPk("0000" + ac.RowKey).Count() != 0)
          _errors.Add("", "Account contains products");
      return _errors;
    }
