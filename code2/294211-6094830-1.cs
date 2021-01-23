    object createdObject = null;
    switch (element.Attribute("Type").Value)
    {
    case "System.Windows.Forms.Label":
        createdObject = new System.Windows.Controls.Label();
        break;
    case "System.Windows.Forms.Button":
        createdObject = new System.Windows.Controls.Button();
        break;
    }
    
    var fe = createdObject as FrameworkElement;
    if (fe != null)
    {
        fe.Name = element.Attribute("Name").Value;
        fe.Width = Convert.ToDouble(element.Attribute("Width").Value);
        fe.Height = Convert.ToDouble(element.Attribute("Height").Value);
    }
    
    var ce = createdObject as ContentElement;
    if (ce != null)
    {
         ce.Content = element.Attribute("Value").Value;
    }
    
    return createdObject;
