    var name = element.Attribute("Name").Value;
    var text = element.Attribute("Value").Value;
    var width = Convert.ToDouble(element.Attribute("Width").Value);
    var height = Convert.ToDouble(element.Attribute("Height").Value);
    
    object createdObject = null;
    switch (element.Attribute("Type").Value)
    {
    case "System.Windows.Forms.Label":
        createdObject = new System.Windows.Controls.Label();
    case "System.Windows.Forms.Button":
        createdObject = new System.Windows.Controls.Button();
    }
    
    var fe = createdObject as FrameworkElement;
    if (fe != null)
    {
        fe.Name = name;
        fe.Width = width;
        fe.Height = height;
    }
    
    var ce = createdObject as ContentElement;
    if (ce != null)
    {
         ce.Content = text;
    }
    
    return createdObject;
