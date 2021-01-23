    public class RepositoryException : Exception
    {
        public RepositoryException() : base()
        {
        }
        public ServiceException(string key, string value) : base()
        {
            base.Data.Add(key, value);
        }
    
        public RepositoryException(string message) : base(message)
        {
        }
    
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public Boolean Delete(Account account)
    {
        try 
        { 
            _accountRepository.Delete(account); 
            return true;
        }
        catch (Exception ex)
        { 
            throw new RepositoryException("", "Error when deleting account");            
            // throw new RepositoryException("Error when deleting account", ex);
            // OR just
            // throw new RepositoryException("Error when deleting account");
        }
    }
