    public static IEnumerable<Control> GetAllControls(Control parent)
    {
        if(null == parent) return null;
        return new Control[] { parent }.Union(parent.Controls.OfType<Control>().SelectMany(child => GetAllControls(child));
    }
