    public static void EffectsRemove_Click(object sender, EventArgs e)
    {
        DeleteItemsFromList(
            (Button)sender, 
            (ListBox)ActiveForm["EffectsList"], 
            "Effects");
    }
    
    public static void LayersRemove_Click(object sender, EventArgs e)
    {
        DeleteItemsFromList(
            (Button)sender, 
            (ListBox)ActiveForm["LayersList"], 
            "Layers");
    }
    
    public static void ObjectsRemove_Click(object sender, EventArgs e)
    {
        DeleteItemsFromList(
            (Button)sender, 
            (ListBox)ActiveForm["ObjectsList"], 
            "Objects");
    }
    
    public static void DeleteItemsFromList(
        Button sender, 
        ListBox control, 
        string action)
    {
        control.Items.Add(sender.Name);
        var selectedItem = control.SelectedItem;
        if ( selectedItem == null )
            return;
    
        Refresh = false;
        UpdateUI action;
        Refresh = true;
    }
