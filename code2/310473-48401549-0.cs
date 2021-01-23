     public void ChangeSection(object sender, SelectionChangedEventArgs e)
        {
            // sender is the datagrid
            if (sender == null)
                return;
            // So, SelectedItem can be of class A, AB or AC:
            var s = (sender as DataGrid).SelectedItem;
            if (s is AB)
                (s as AB).SubClassPanel = this.FindResource("AB") as StackPanel;
            else
            {
                if (s is AC)
                    (s as AC).SubClassPanel = this.FindResource("AC") as StackPanel;
                else
                {
                     // or show just the base class members: 
                     (s).SubClassPanel = this.FindResource("Nothing") as StackPanel;
                }
            }
        }
