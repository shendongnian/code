    public IEnumerable<ValidationResult> ValidateForDeletion(Account ac)
    {
        var account = _accountRepository.GetPkRk(ac.PartitionKey, ac.RowKey);
        if (account == null)
        {
            yield return new ValidationResult("Account does not exist");
        }
        if (_productRepository.GetPk("0000" + ac.RowKey).Count() != 0)
        {
            yield return new ValidationResult("Account contains products");
        }
    }
