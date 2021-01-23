            this.listView1.ItemSelectionChanged += this.HandleOnListViewItemSelectionChanged;
    
            private void HandleOnListViewItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
            {
                if (e.IsSelected)
                {
                    this.detailsLabel.Text = this.GetDetails(e.Item);
                }
                else
                {
                    this.detailsLabel.Text = String.Empty;
                }
            }
