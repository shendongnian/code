    protected void C1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            L1.Items.Add(C1.SelectedDate.ToShortDateString());
           
            ListItem[] x = new ListItem[L1.Items.Count];
            L1.Items.CopyTo(x, 0);
            Session["x"] = x;
            ListItem[] collection = (ListItem[])Session["x"];
            foreach (var item in collection)
            {
                
                Label1.Text += item.Text + "</br>";
            }
        }
