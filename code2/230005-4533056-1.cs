    System.Collection.Generic.Dictionary<string, Label> labels = new System.Collection.Generic.Dictionary<string, Label>();
    int i = 0;
    while (true)
    {
        Label newLabel = new Label();
        string name = string.Format("label_{0}", i++);
        labels.Add(name, newLabel);
    }
