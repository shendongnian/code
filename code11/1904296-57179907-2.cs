    int[] selectedRows = gridView1.GetSelectedRows();
    for (int i = 0; i < selectedRows.Length; i++)
    {
       ...
       cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = gttDXGridView1.GetRowCellValue(selectedRows[i], yourColumn) });
       ...
	}
