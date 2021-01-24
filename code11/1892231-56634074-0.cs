    private void CbInKuLi_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(cbInKuLi.ItemsSource);
            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(cbInKuLi.Text)) return true;
                else
                {
                    Model x = (Model)o;
                    string filterText = cbInKuLi.Text;
                    if (x.Text.ToLowerInvariant().Contains(filterText))
                        return true;
                    else
                        return false;
                }
            });
            itemsViewOriginal.Refresh();
            cbInKuLi.IsDropDownOpen = true;
            var textbox = (TextBox)cbInKuLi.Template.FindName("PART_EditableTextBox", cbInKuLi);
            textbox.Select(textbox.Text.Length, textbox.Text.Length);
        }
