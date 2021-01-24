    private void ListviewEnter(object sender, PointerRoutedEventArgs e)
            {​
                ListViewItem item = sender as ListViewItem;​
                Person p = item.DataContext as Person;​
                p.IsShow = true;​
            }​
    ​
            private void ListviewExit(object sender, PointerRoutedEventArgs e)​
            {​
                ListViewItem item = sender as ListViewItem;​
                Person p = item.DataContext as Person;​
                p.IsShow = false;​
    ​
            }
