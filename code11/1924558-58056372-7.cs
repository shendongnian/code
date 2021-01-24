    public void CheckReference(Object reference)
    {
        try
        {
            var blarf = reference.name;
        }
        catch (MissingReferenceException) // General Object like GameObject/Sprite etc
        {
            Debug.LogError("The provided reference is missing!");
        }
        catch (MissingComponentException) // Specific for objects of type Component
        {
            Debug.LogError("The provided reference is missing!");
        }
        catch (UnassignedReferenceException) // Specific for unassigned fields
        {
            Debug.LogWarning("The provided reference is null!");
        }
        catch (NullReferenceException) // Any other null reference like for local variables
        {
            Debug.LogWarning("The provided reference is null!");
        }
    }
