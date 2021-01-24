    public void UpdateComputerStatus() // <<< Bound to toolbar button Click event
    {
        TreeViewItemViewModel selectedItem = Children.Where(c => c.IsSelected == true).FirstOrDefault();
        OUModel ou = selectedItem as OUModel;
        if (ou != null)
        {
            ou.QueryRemoteComputers();
        }  
    }
