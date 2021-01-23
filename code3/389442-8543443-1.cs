    public void Delete(Account account) {
      try {
        _accountRepository.Delete(account);
      } catch(Exception ex) {
        AccountException a = new AccountException(ex);
        a.Errors.Add("", "Error when deleting account");
        throw a;
      }
    }
    public void ValidateNoDuplicate(Account ac) {
      var accounts = GetAccounts(ac.PartitionKey);
      if (accounts.Any(b => b.Title.Equals(ac.Title) &&
                                !b.RowKey.Equals(ac.RowKey))) {
        AccountException a = new AccountException();
        a.Errors.Add("Account.Title", "Duplicate");
        throw a;
      }
    }
