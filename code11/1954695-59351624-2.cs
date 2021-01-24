    // Get a toast XML template
    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
    
    // Fill in the text elements
    XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
    for (int i = 0; i < stringElements.Length; i++)
    {
        stringElements[i].AppendChild(toastXml.CreateTextNode("Line " + i));
    }
    
    // Specify the absolute path to an image
    String imagePath = "file:///" + Path.GetFullPath("toastImageAndText.png");
    XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
    
    ToastNotification toast = new ToastNotification(toastXml);
