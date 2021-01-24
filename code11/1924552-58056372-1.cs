    public void CheckReference(Object reference)
    {
        try
        {
            var blarf = reference.name;
        }
        catch (MissingReferenceException)
        {
            Debug.LogError("The provided reference is missing!");
        }
        catch (MissingComponentException)
        {
            Debug.LogError("The provided reference is missing!");
        }
        catch (UnassignedReferenceException)
        {
            Debug.LogWarning("The provided reference is null!");
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("The provided reference is null!");
        }
    }
