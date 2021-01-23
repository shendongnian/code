        private void CreateMenuWithXmlFile()
        {
           string path = @"C:\MyXmlFile.xml";
           DataSet ds = new DataSet();
           ds.ReadXml(path);
           Menu menu = new Menu();
           menu.MenuItemClick += new MenuEventHandler(menu_MenuItemClick);
           for (int i = 0; i < ds.Tables.Count; i++)
           {
            MenuItem parentItem = new MenuItem((string)ds.Tables[i].TableName);
            menu.Items.Add(parentItem);
            for (int c = 0; c < ds.Tables[i].Columns.Count; c++)
            {
              MenuItem column = new MenuItem((string)ds.Tables[i].Columns[c].ColumnName);
              menu.Items.Add(column);
            for (int r = 0; r < ds.Tables[i].Rows.Count; r++)
            {
             MenuItem row = new MenuItem((string)ds.Tables[i].Rows[r][c].ToString());
              parentItem.ChildItems.Add(row);
            }
        }
       }
       Panel1.Controls.Add(menu);
       Panel1.DataBind();
     }
