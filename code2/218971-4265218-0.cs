    var rows = new List<List<string>>()
          {
              new List<string>() {"List1-1", "List1-2", "List1-3"},
              new List<string>() {"List2-1", "List2-2", "List2-3"}
          };
    GridView gv = new GridView();
    this.grid.View = gv;
    gv.Columns.Add(new GridViewColumn(){DisplayMemberBinding = new Binding(".[0]")});
    gv.Columns.Add(new GridViewColumn(){DisplayMemberBinding = new Binding(".[1]")});
    gv.Columns.Add(new GridViewColumn(){DisplayMemberBinding = new Binding(".[2]")});
    this.grid.ItemsSource = rows;
