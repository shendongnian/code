    private void EmptyCollection (ICollection collection)
    {   // throws all elements in the list, if needed disposes them
        foreach (object o in collection)
        {
            System.IDisposable disposableObject = o as System.IDisposable;
            o = null;
            if (disposableObject != null)
            {
                disposableObject.Dispose();
            }
        }
    }
