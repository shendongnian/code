        ListViewItem item;
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                item = new ListViewItem(reader.getString(0));
                item.SubItems.Add(reader.getString(1));
                item.SubItems.Add(reader.getString(2));
                listView1.Items.Add(item);
            }
        }
       
    }
