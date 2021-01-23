    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    protected void VerifyPropertyName(String propertyName)
    {
        if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            Debug.Fail(String.Format("Invalid property name. Type: {0}, Name: {1}",
                GetType(), propertyName));
    }
