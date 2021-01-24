    var field = worksheet.View.GetType().GetProperty("TopNode", BindingFlags.NonPublic | BindingFlags.Instance);
    XmlNode node = (XmlNode) field.GetValue(worksheet.View);
    var pane = node.SelectSingleNode("//*[local-name()='pane']");
    
    var state = pane.Attributes?["state"]?.Value;
    var xSplit= pane.Attributes?["xSplit"]?.Value;
    var ySplit= pane.Attributes?["ySplit"]?.Value;
