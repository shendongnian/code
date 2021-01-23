    // Return all controls by name 
    // that are descendents of a specified control. 
    List<T> GetControlByName<T>(
        Control controlToSearch, string nameOfControlsToFind, bool searchDescendants) 
        where T : class
    {
        List<T> result;
        result = new List<T>();
        foreach (Control c in controlToSearch.Controls)
        {
            if (c.Name == nameOfControlsToFind && c.GetType() == typeof(T))
            {
                result.Add(c as T);
            }
            if (searchDescendants)
            {
                result.AddRange(GetControlByName<T>(c, nameOfControlsToFind, true));
            }
        }
        return result;
    }
