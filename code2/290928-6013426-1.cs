    // In whatever method loads the file
    string fileName = GetFileNameFromUser();
    if (fileName != null)
    {
        var rootElement = GetRootElementOfXmlFile(fileName);
        foreach (var controlTag in rootElement)
        {
            ProcessControlTag(controlTag);
        }
    }
    
    private static void ProcessControlTag(XElement controlTag)
    {
        var type = GetControlType(controlTag);
        if (type == null)
        {
            return;
        }
    
        var control = CreateControl(controlType, controlTag);
        Canvas.Controls.Add(control);
    }
    
    private static void CreateControl(Type controlType, XElement controlTag)
    {
        var control = (Control)Activator.CreateInstance(controlType);
        AddCommonControlModifications(control, controlTag);
        
        if (controlType.Name == "Label")
        {
            AddLabelModifications(control, controlTag);
        }
        else if (controlType.Name == "LinkLabel")
        {
            AddLinkLabelModifications(control, controlTag);
        }
        else if (controlType.Name == "PictureBox")
        {
            AddPictureBoxModifications(control, controlTag);
        }
    }
