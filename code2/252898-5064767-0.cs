    public IEnumerable<WebControl> GetNonTranslatableChildren(WebControl control)
    {
        foreach(WebControl c in control.Controls) 
        {
            if(
            c.GetType()
            .GetCustomAttributes(true)
            .Count(item => item is DoNotTranslateAttribute) > 0)
                yield return c;
        }        
    }
