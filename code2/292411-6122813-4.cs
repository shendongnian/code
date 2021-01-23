    try
    {
       // ... same as above ...
    }
    catch (Exception ex)
    {
       if (!(ex is OutOfMemoryException || ex is AccessViolationException || /* others */)
         LogCommand();
     
       throw;  // rethrow! original exception.
    }
