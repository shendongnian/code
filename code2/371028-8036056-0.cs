        List<string> list = new List<string>();
        for (int i = 0; i < GridView1.Columns.Count ; i++)
        {
            list.Add(GridView1.Columns[i].HeaderText);
        }
        DropDownList1.DataSource = list;
