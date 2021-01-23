    protected void thegrid_RowSourceNeeded(object sender, GridViewRowSourceNeededEventArgs e)
            {
                e.Template.Rows.Clear();
                patentdata cparent = e.ParentRow.DataBoundItem as patentdata;
    
                foreach (subdataobject sub in parentdata.subs)
                {
                    GridViewRowInfo row = e.Template.Rows.NewRow();
                    row.Tag = sub;
                    row.Cells["Name"].Value = sub.Name;
                    e.SourceCollection.Add(row);
                }
            }
