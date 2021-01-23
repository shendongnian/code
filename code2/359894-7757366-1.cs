    Delegate[] actions = updateActions.GetInvocationList();
    foreach ( Delegate del in actions )
    {
        Debug.Log( del.Method.ReflectedType.FullName + "." + del.Method.Name );
    }
