    // Load the data on the background...
    var data = datasource.Where(i => i.Category == worker);
    // Do all work on the UI thread
    tabControl1.Dispatcher.Invoke(DispatcherPriority.Normal, 
                    (Action)(() => 
                    {
                        TabItem tbItem = new TabItem();
                        tbItem.Header = worker;
                        //Grid & ListBox(within tab item)
                        Grid grid = new Grid();
                        ListBox listBox = new ListBox();
                        listBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                        listBox.VerticalAlignment = VerticalAlignment.Stretch;
                        listBox.ItemsSource = data;
                        grid.Children.Add(listBox);
                        tbItem.Content = grid;
                        tabControl1.Items.Add(tbItem); 
                    }));    
