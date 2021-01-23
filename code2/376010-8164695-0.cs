    public void ThrowException(Exception e)
    {
        if (ConditionMet)
        {
            if(e is NullReferenceException || e is FileNotFoundException)
            {
                throw e;
            }
            throw new SystemException(e.Message);
        }
    }
