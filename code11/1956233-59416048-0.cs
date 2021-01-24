    public T TryCatch<T>(Func<T> tryCatched, T returnedOnFailure)
    {
        try
        {
            return tryCatched();
        }
        catch
        {
            return returnedOnFailure;
        }
    }
