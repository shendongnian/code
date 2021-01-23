    private static PropertyInfo RequiresUpdateProperty;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        RequiresUpdateProperty = RequiresUpdateProperty?? typeof(UpdatePanel).GetProperty("RequiresUpdate", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    }
    
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if ((bool)RequiresUpdateProperty.GetValue(UpdatePanel2, null))
        {
            // gotcha!
        }
    }
