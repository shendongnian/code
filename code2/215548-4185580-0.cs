    Type t = ...;
    if (t.IsGenericType)
    {
        Type g = t.GetGenericTypeDefinition();
        MessageBox.Show(g.Name);                                // displays "List`1"
        MessageBox.Show(g.Name.Remove(g.Name.IndexOf('`')));    // displays "List"
    }
