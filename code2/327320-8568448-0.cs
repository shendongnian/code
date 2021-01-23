    [GenerateScriptType(typeof(ColorObject), ScriptTypeId = "Color")]
    [WebMethod]
    public string[] GetDefaultColor()
    {
        // Instantiate the default color object.
        ColorObject co = new ColorObject();
    
        return co.rgb;
    }
