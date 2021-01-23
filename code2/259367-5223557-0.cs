        private void idProveedorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.SelectedItems.Count == 0)
            {
                ProdList.Last().IdProv.Clear();
                return;
            }
            else
            {
                Models.Proveedor lastSelected = list.SelectedItems[list.SelectedItems.Count - 1] as Models.Proveedor;
                if (lastSelected != list.SelectedItem)
                    PProdList.Last().IdProveedorInt = lastSelected.Id;
            }
        }
