    // perpare ListView beforehand
    this.listView.Columns.Add("First name");
    this.listView.Columns.Add("Email");
    this.listView.Columns.Add("Country");
    this.listView.View = View.Tile;
    // if tile height is too small, some data might not be visible
    this.listView.TileSize = new Size(180, 50); 
    // sample data
    var people = new[] 
    {
        new { FirstName = "John", Email = "john@domain.com", Country = "USA" },
        new { FirstName = "Betty", Email = "betty72@mail.org", Country = "Canada" },
        new { FirstName = "Steven", Email = "stv@domain.net", Country = "Brazil" },
    };
    foreach (var person in people)
    {
         ListViewItem item = new ListViewItem(person.FirstName);
         item.SubItems.Add(person.Email);
         item.SubItems.Add(person.Country);
         this.listView.Items.Add(item);
    }
