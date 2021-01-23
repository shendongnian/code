    public static IEnumerable<T> GetIndividualDelegates<T>(this T multiDelegate)
        where T : class
    {
        if (multiDelegate == null)
        {
            yield break;
        }
        Delegate d = (Delegate)(object) multiDelegate;
        foreach (Delegate item in d.GetInvocationList())
        {
             yield return (T)(object) item;
        }    
    }
