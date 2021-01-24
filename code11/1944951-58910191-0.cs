    public void YourCommandMethod(object obj)
        {
            try
            {
                //Get our list view
                ListView listview = (ListView)obj;
                string sNavigationPath = string.Empty;
                //this is a work around to get selected item without clicking on list view, just the coordinates
                var item = VisualTreeHelper.HitTest(listview, Mouse.GetPosition(listview)).VisualHit;
                // find ListViewItem (or null)
                while (item != null && !(item is ListViewItem))
                    item = VisualTreeHelper.GetParent(item);
                if (item != null)
                {
                    //Convert item to Listview
                    ListViewItem listviewItem = (ListViewItem)item;
                    //Get the data context wich hold the necessary info
                    var _dataContext = listviewItem.DataContext;
                    //Convert back to our customized listview
                    var _list = (ListViewItems)_dataContext;
                    // Do whatever you want with your elements
                }
                
            }
            catch (Exception ex)
            {
                StaticElements.showErrorFlyout(ex.Message);
            }
        }
