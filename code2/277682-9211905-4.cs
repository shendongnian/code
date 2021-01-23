     GridView viewLayout = new GridView();
            for (int i = 0; i < Apprefs.tables[0].Headers.Count(); i++)
            {
                GridViewColumn gvc = new GridViewColumn();
                string colName = Apprefs.tables[0].Headers[i];
                gvc.Header = colName;
                gvc.Width = 80;
                gvc.CellTemplate = SetTemplete(i); ;
                viewLayout.Columns.Add(gvc);
           }
            listview1.View = viewLayout;
            //set binding
            listview1.ItemsSource = Apprefs.tables[0].Rows;
