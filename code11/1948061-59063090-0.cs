    var f = new Form();
    f.Controls.Add(new Label() { Name = "x1" });
    f.Controls.Add(new Label() { Name = "y" }); 
    f.Controls.Add(new Label() { Name = "x2" });
    f.Controls
        .Cast<Control>()
        .Where(c => c.Name.StartsWith("x")).ToList()
        .ForEach(c => f.Controls.Remove(c));
    Debug.Assert(f.Controls.Count == 1);
