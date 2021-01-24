    protected void Page_Load(object sender, EventArgs e)
    {
        ImageCheckBoxList1.Items = new List<ImageListItem>()
        {
            new ImageListItem("Item 1", "Item1", "Images/1.png"),
            new ImageListItem("Item 2", "Item2", "Images/2.png"),
            new ImageListItem("Item 3", "Item3", "Images/3.png")
        };
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        foreach (ImageListItem item in ImageCheckBoxList1.Items)
        {
            if (item.Checked)
            {
                sb.AppendLine($"{item.Text} with value {item.Value} is checked.");
            }
        }
        Label1.Text = sb.ToString();
    }
