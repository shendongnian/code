     public class foo
     {
        string FeedName {get;set;}
        string FeedUrl {get;set;}
     }
     public void InitialiseListView(List<Foo> Items)
     {
        listFeedSearch.ItemsSource = Items;
     }
     private void SelectButtonClick(object sender, RoutedEventArgs e)
     {
        foo b = (foo)(sender as Button).CommandParameter;
        string s = string.format("Name: {0} URL: {1}",b.FeedName,b.FeedUrl);
        MessageBox.Show(s);
    }
