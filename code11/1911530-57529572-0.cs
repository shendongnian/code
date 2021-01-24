    // schema built in VS designer...
       static public DataTable APT = new SCTData.APTDataTable();
    // Table populated from FAA fixed-column text files (cols vary by file)
        ReadFixes.FillAPT();
    // Assign the table to the datagridview, apply filter and sort
                DgvArpt.DataSource = APT;
                (DgvArpt.DataSource as DataTable).DefaultView.RowFilter = filter;
                AdjustColumnOrderNSort(DgvArpt);
    // Loop the filtered datagrid to make "Selected" col = true
                UpdateSelected(DgvArpt,true);
            private void UpdateSelected (DataGridView dgv, bool hasFilter = false)
            {
                // If the filter is applied, selected boxes are true
                // otherwise, ALL the selected boxes are false
                // But if the ShowAll box is checked, ignore the update
                if (chkboxShowAll.Checked == false)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        row.Cells["Selected"].Value = hasFilter;
                    }
                }
            }
