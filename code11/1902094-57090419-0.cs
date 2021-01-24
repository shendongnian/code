    void CallSaveChanges()
    {
        try
        {
            _baseRepository.SaveChanges();
        }
        catch (ArgumentNullException) { }
    }
