    public IEnumerable<Control> GetNonTranslatableChildren(Control control)
    {
        foreach(Control c in control.Controls) 
        {
            if(
            c.GetType()
            .GetCustomAttributes(true)
            .Count(item => item is DoNotTranslateAttribute) > 0)
                yield return c;
        }        
    }
