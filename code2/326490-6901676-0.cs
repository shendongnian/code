    string[] paths = { "FieldOutputs/Capacity", "EngOutputs/Performance", 
                       "EngOutputs/Unit/Efficiency"};
    foreach (string path in paths)
    {
        XElement element = parent.XPathSelectElement(path);
        if (element != null)
        {
            // ...
        }
    }
