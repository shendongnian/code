       public static void ItemSetFocus(DataGrid Dg, int SelIndex)
        {
            if (Dg.Items.Count >= 1 && SelIndex < Dg.Items.Count)
            {
               Dg.ScrollIntoView(Dg.Items.GetItemAt(SelIndex));
               Dg.SelectionMode = DataGridSelectionMode.Single;
               Dg.SelectionUnit = DataGridSelectionUnit.FullRow;
               Dg.SelectedIndex = SelIndex;
               DataGridRow row = (DataGridRow)Dg.ItemContainerGenerator.ContainerFromIndex(SelIndex);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
