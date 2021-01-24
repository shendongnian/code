    // signature: more natural have "parent, excluded":
    // "scan parent without excluded" 
    // IEnumerable<Control> - now I can pass almost any collection, say array
    public static bool Check_Inputs_Empty_Exception<T>(Control parent, 
                                                       IEnumerable<T> excluded) 
      where T : Control {
      if (null == parent)
        throw new ArgumentNullException(nameof(parent)); 
    
      // HashSet is more efficient (and convenient) for Contains then List 
      HashSet<T> exceptions = excluded == null 
        ? new HashSet<T>()
        : new HashSet<T>(excluded);
    
      // array of Controls of type T on parent with empty Text and not within exceptions
      var empty = parent
        .Controls
        .OfType<T>()
        .Where(control => !exceptions.Contains(control))
        .Where(control => string.IsNullOrEmpty(control.Text))
     // .OrderBy(control => control.Name)  //TODO: you may want to sort the controls
        .ToArray();
    
      foreach (T ctrl in empty)
        MessageBox.Show($"{ctrl.Name} is empty");
     
      return empty.Any();
    }
    
    // If we don't have controls to exclude
    public static bool Check_Inputs_Empty_Exception<T>(Control parent) 
      where T : Control {
        return Check_Inputs_Empty_Exception<T>(parent, new T[0]);
    }
