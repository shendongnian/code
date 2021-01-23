    static bool AreAnyObjectsVisible(IEnumerable<MyObject> myObjects)
    {
        foreach (var myObject in myObjects)
        {
            if (myObject.IsVisible) return true;
        }
        return false;
    }
