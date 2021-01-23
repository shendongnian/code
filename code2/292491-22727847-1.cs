        public void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.MyListView.SelectedItems.Count > 2)
            {
                this.MyListView.SelectedItems.RemoveAt(0);
            }
        }
 
