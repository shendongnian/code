    /// <summary>
    /// this is an extension method to iterate though all controls in a control collection
    /// put this in some static library somewhere
    /// </summary>
    /// <param name="controls"></param>
    /// <returns></returns>
    public static IEnumerable<Control> All(this ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            foreach (Control grandChild in control.Controls.All())
                yield return grandChild;
    
            yield return control;
        }
    }
    
    
    /// <summary>
    /// this function uses reflection to check if the validation group exists, and then set it to the 
    /// specified string
    /// </summary>
    /// <param name="ValidationGroup"></param>
    private void SetValidationGroup(string ValidationGroup)
    {
        //set the validation group for all controls
        if (ValidationGroup.IsNotNullOrEmpty())
        {
            foreach (Control c in Controls.All())
            {
                var Properties = c.GetType().GetProperties();
                var vg = Properties.Where(p => p.Name == "ValidationGroup").SingleOrDefault();
                if (vg != null)
                {
                    vg.SetValue(c, ValidationGroup, null);
                }
    
            }
    
        }
    }
