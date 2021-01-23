    myDataGrid.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);
    :
    :
    void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        if (myDataGrid.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            DataGridRow row = (DataGridRow)myDataGrid.ItemContainerGenerator.ContainerFromIndex(rowIdx);
            if (row == null)
            {
                myDataGrid.UpdateLayout();
                myDataGrid.ScrollIntoView(myDataGrid.Items[rowIdx]);
                row = (DataGridRow)myDataGrid.ItemContainerGenerator.ContainerFromIndex(rowIdx);
            }
        }
    }
