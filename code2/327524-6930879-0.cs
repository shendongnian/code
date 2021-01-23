    var gridView = new GridView();
    gridView.Columns.Add(new GridViewColumn() {
        Header = "Devise",
        DisplayMemberBinding = new Binding() { Path = "devise" },
        Width = 80
    });
    // ...
    var listView = new ListView() {
        Name = "listView",
        Margin = new Thickness(0, 0, 0, 164),
        View = gridView
    };
