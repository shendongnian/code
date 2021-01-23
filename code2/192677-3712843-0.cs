        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<CustomClass> sourceCol = listView.DataContext as ObservableCollection<CustomClass>;
            if (sourceCol != null)
                ActiveItemCount = sourceCol.Count(x => x.Active);
        }
