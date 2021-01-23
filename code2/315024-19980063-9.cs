    private void EmptySequence (IEnumerable sequence)
    {   // throws away all elements in the sequence, if needed disposes them
        foreach (object o in sequence)
        {
            System.IDisposable disposableObject = o as System.IDisposable;
            o = null;
            if (disposableObject != null)
            {
                disposableObject.Dispose();
            }
        }
    }
