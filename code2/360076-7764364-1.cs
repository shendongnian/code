        private void DataGridRow_MouseDoubleClick(
               object sender, MouseButtonEventArgs e)
        {
            var dgRow = sender as Microsoft.Windows.Controls.DataGridRow;
            var cellContentElement = e.OriginalSource as UIElement;
        }
