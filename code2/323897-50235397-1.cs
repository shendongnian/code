    private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
            {
                if (e.Key == System.Windows.Input.Key.Delete)
                {
    
                    var lst = new List<object>();
    
                    foreach (var itemSelected in ListBox.SelectedItems)
                    {
                        lst.Add(itemSelected);
                    }
    
                    foreach (var lstitem in lst)
                    {
                        ListBox.Items.Remove(lstitem);
                    }
    
                }
            }
