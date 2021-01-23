            DataGridRow row = (DataGridRow)dgContacts.ItemContainerGenerator.ContainerFromItem(item);
                var cell = dgContacts.Columns[0];
                
                var cp = (ContentPresenter)cell.GetCellContent(row);
                CheckBox rowSelected = (CheckBox)cp.ContentTemplate.FindName("Edit", cp);
