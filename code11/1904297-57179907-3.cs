    int[] selectedRows = gridView1.GetSelectedRows();
    for (int i = 0; i < selectedRows.Length; i++)
    {
       DataRow row = gridView1.GetDataRow(selectedRows[i]);
       ...
       cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = row["Id"] });
       ...
	}
