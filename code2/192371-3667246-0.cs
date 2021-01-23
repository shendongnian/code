            var list = ListBox1.Items.Cast<ListItem>().Select(item => item.Value).ToList();
            list.Sort();
    
            ListBox2.DataSource =list;
            ListBox2.DataBind();
