    using System.Data.Entity;
    IEnumerable<Item> items = MethodCreatingItems();
    var observableItems = new System.Collections.ObjectModel.ObservableCollection<Item>(items);
    System.ComponentModel.BindingList<Item> source = observableItems.ToBindingList();
    MyDataGridView.DataSource = source;
