    /// <summary>
    /// Recursively searches for a control within the heirarchy of a given control.
    /// </summary>
    /// <param name="root">The control to search within.</param>
    /// <param name="id">The ID of the control to find.</param>
    /// <returns>The Control object of the found control, or null if the control isn't found.</returns>
    public static Control FindControlRecursive(Control root, string id)
    {
    	if (root.ID == id) return root;
    
    	foreach (Control c in root.Controls)
    	{
    		Control t = FindControlRecursive(c, id);
    		if (t != null) return t;
    	}
    
    	return null;
    }
    
    /// <summary>
    /// Recursively searches for a control within the heirarchy of a given control using the Client ID
    /// of the control. Calling this too early in the lifecycle may not behave as expected.
    /// </summary>
    /// <param name="root">The control to search within.</param>
    /// <param name="clientID">The Client ID of the control to find.</param>
    /// <returns>The Control object of the found control, or null if the control isn't found.</returns>
    public static Control FindControlRecursiveByClientID(Control root, string clientID)
    {
     if (0 == String.Compare(root.ClientID, clientID, true)) return root;
    
     foreach (Control c in root.Controls)
     {
      Control t = FindControlRecursiveByClientID(c, clientID);
      if (t != null) return t;
     }
    
     return null;
    }
    
    /// <summary>
    /// Recursively searches for a group of controls within the heirarchy of a given control tree using the ID
    /// of the control.
    /// </summary>
    /// <param name="root">The control tree to search within.</param>
    /// <param name="id">The ID of the control to find.</param>
    /// <returns>
    /// A collection of the found controls. The collection will be empty if none are found.
    /// </returns>
    public static List<Control> FindControlsRecursive(Control root, string id)
    {
     List<Control> collection = new List<Control>();
     FindControlRecursive(root, id, collection);
     return collection;
    }
    
    private static void FindControlRecursive(Control root, string id, List<Control> collection)
    {
     foreach (Control c in root.Controls)
     {
      if (0 == String.Compare(c.ID, id, true)) collection.Add(c);
      else FindControlRecursive(c, id, collection);
     }
    }
    
    /// <summary>
    /// Recursively searches for a control within the heirarchy of a given control using the type
    /// of the control.
    /// </summary>
    /// <typeparam name="T">The type of the control to find.</typeparam>
    /// <param name="root">The control to search within.</param>
    /// <returns>
    /// The Control object of the found control, or null if the control isn't found.
    /// </returns>
    public static T FindControlRecursiveByType<T>(Control root)
     where T : Control
    {
     if (root is T) return (T)root;
     foreach (Control c in root.Controls)
     {
      Control t = FindControlRecursiveByType<T>(c);
      if (t != null) return (T)t;
     }
     return null;
    }
    
    /// <summary>
    /// Recursively searches for a set of controls within the heirarchy of a given control using the type
    /// of the control.
    /// </summary>
    /// <typeparam name="T">The type of the control to find.</typeparam>
    /// <param name="root">The control to search within.</param>
    /// <returns>
    /// A generic List object containing the controls found, or an empty List of none were found.
    /// </returns>
    public static List<T> FindControlsRecursiveByType<T>(Control root)
     where T : Control
    {
     List<T> collection = new List<T>();
     FindControlRecursiveByType<T>(root, collection);
     return collection;
    }
    
    private static void FindControlRecursiveByType<T>(Control root, List<T> collection)
     where T : Control
    {
     foreach (Control c in root.Controls)
     {
      if (c is T) collection.Add((T)c);
      else FindControlRecursiveByType<T>(c, collection);
     }
    }
