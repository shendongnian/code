    System.Collections.Generic.List<Label> labels = new System.Collections.Generic.List<Label>();
    int i = 0;
    while (true)
    {
        Label newLabel = new Label();
        newLabel.Name = string.Format("label_{0}", i++);
        labels.Add(newLabel);
    }
