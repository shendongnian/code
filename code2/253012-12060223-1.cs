    while (true)
    {
        T ret = null;
        try
        {
            if (!enumerator.MoveNext())
            {
                break;
            }
            ret = enumerator.Current;
        }
        catch (Exception ex)
        {
            // handle the exception and end the iteration
            // probably you want it to re-throw it
            break;
        }
        // the yield statement is outside the try catch block
        yield return ret;
    }
