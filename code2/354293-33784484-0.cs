    Items.CollectionChanged += (sender, e) =>
    {
        if (!Items.Contains(Selected))
        {
            Selected = Items.FirstOrDefault();
        }
    };
