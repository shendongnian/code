      private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (listBox1.Items.Count <= 0)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = "Content " + i;
                        listBox1.Items.Insert(i, item);
                      //  listBox1.SelectedItem = item;
                    }
                    listBox1.SelectedItem = listBox1.Items[12];
                }
                else
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = "Content " + listBox1.Items.Count;
                    listBox1.Items.Insert(listBox1.Items.Count, item);
                  //  listBox1.SelectedItem = item;
                }
    
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    new Action(delegate()
                    {
                        listBox1.ScrollIntoView(listBox1.SelectedItem);
                    }));
    
            }
