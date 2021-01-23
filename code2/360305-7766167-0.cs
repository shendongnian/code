    public class MyListViewItem : ListViewItem {
        public List<object> Tags {get; set;}
    }
    
    // ... elsewhere
    
    var item = new MyListViewItem {
        Text = "Hello world!",
        Tags = new List<object> { null, true, 15, "asdf", 78.7 }
    };
    this.listView1.Items.Add(item);
