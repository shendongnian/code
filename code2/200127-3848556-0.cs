    dataGrid.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);
    
    void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
            {
                if (dataGrid.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    dataGrid.SelectedIndex = 0;
                }
            }
