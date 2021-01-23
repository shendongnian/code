        DropDownList ddl = new DropDownList();
        while (rs.Read())
        {
            string id = rs.GetGuid(0).ToString();
            int depth = rs.GetInt32(3);
            string text = rs.GetString(2);
            string padding = String.Concat(Enumerable.Repeat("&#160;", 4 * depth));
            ddl.Items.Add(new ListItem(padding + text, id));
        }
