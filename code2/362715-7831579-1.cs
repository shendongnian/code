     public void OnAdd(object sender)
        {
            ToggleButton tb = sender as ToggleButton;
            EmpCollectionView.SortDescriptions.Clear();
            if (tb.IsChecked == true)
            {
                
                EmpCollectionView.SortDescriptions.Add(new SortDescription(tb.Content.ToString(), ListSortDirection.Ascending));
                EmpCollectionView.Refresh();
            }
            else
            {
                EmpCollectionView.SortDescriptions.Add(new SortDescription(tb.Content.ToString(), ListSortDirection.Descending));
                EmpCollectionView.Refresh();
            }
        }
