    public ViewModel()
    {
        Items = new ObservableCollection<Model>();
        Items.Add(new Model {Name = "11111"});
        Items.Add(new Model {Name = "22222"});
        Items.Add(new Model {Name = "33333"});
        
        foreach (var item in Items)
        {
            CollectionViewSource.GetDefaultView(item.ComboBoxItems).Filter =
                (x) => !Items.Where((y) => y != item).Select(y => y.SelectedItem).Any(y => y == (string)x);
            item.PropertyChanged += (s, e) =>
            {
                foreach (var obj in Items.Where((x) => x != item).Select(x => x.ComboBoxItems))
                    CollectionViewSource.GetDefaultView(obj).Refresh();
            };
        }    
    }
