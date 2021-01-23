    for (int i = 0; i < e.Row.Cells.Count; i++)
    {
       label = new Label();
       label.Text = "test";
       e.Row.Cells[i].Controls.Add(label);
       e.Row.Cells[i].Text = "this works";
    }
