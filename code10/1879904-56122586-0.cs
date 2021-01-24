       public class ListViewStateHelper
        {
            private readonly ListView _listView;
            private readonly List<string> _items;
            public ListViewStateHelper(ListView listView)
            {
                _listView = listView;
                _items = new List<string>();
            }
            public void AddItem(string value)
            {
                _items.Add(value);
            }
            public void DeleteItem(string value)
            {
                _items.Remove(value);
            }
            public void Refresh()
            {
                _listView.Items.AddRange(_items.Select(i => new ListViewItem(i)).ToArray());
            }
        }
