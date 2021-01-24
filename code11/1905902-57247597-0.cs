         DataTable dtId = datatable.Clone();
         var rows = datatable.AsEnumerable()
                    .Where(x => x.Field<bool>(2) == true).ToList();
                foreach (var row in rows)
                {
                    dtId.ImportRow(row);
                }
        foreach (DataRow dr in dtId.Rows)
            {
                for (int i = 0; i < CheckedListBox.Items.Count; i++)
                {
                    if ( dr["Id"].ToString() == ((DataRowView)CheckedListBox.Items[i])[0].ToString())
                    {
                        CheckedListBox.SetItemChecked(i, true);
                    }
                }
            }
