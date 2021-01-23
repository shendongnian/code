    Grid = new LiteGridViewModel();
    void _source_DataArrived(LiteTable data)
    {
        Grid.Data = data;  // Fill property in ViewModel
        Grid.UpdateData(); // Call command on ViewModel
    }
