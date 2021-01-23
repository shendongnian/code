        foreach (var item in e.AddedCells)
        {
            var col = item.Column as DataGridColumn;
            var fc = col.GetCellContent(item.Item);
            if (fc is CheckBox)
            {
                Debug.WriteLine("Values" + (fc as CheckBox).IsChecked);
            }
            else if(fc is TextBlock)
            {
                Debug.WriteLine("Values" + (fc as TextBlock).Text);
            }
            //// Like this for all available types of cells
        }
    }
