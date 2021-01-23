    void listview_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            // this is a listview control
			GridView view = this.View as GridView;
			foreach(GridViewColumn c in view.Columns) {
				if(double.IsNaN(c.Width)) {
					c.Width = c.ActualWidth;
				}
				c.Width = double.NaN;
			}
		}
