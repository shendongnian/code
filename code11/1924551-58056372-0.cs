    public void CheckReference(Object reference)
    {
        try
        {
            var blarf = reference.name;
        }
        catch(MissingReferenceException me)
        {
            Debug.LogError("The provided reference is missing!");
        }
        catch(NullReferenceException ne)
        {
            Debug.LogWarning("The provided reference is null!");
        }
    }
