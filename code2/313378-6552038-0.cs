    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
    {
	using (SQLiteTransaction SQLiteTrans = connection.BeginTransaction())
	{
		SQLiteCommand cmd = connection.CreateCommand();
		MessageBox.Show(row.ToString());
		var txtValue = row.Cells["typeDataGridViewTextBoxColumn"].Value;
		if (txtValue.Contains("#"))
		{
			txtValue = String.Format("{0} # {1}", txtValue, max);
		}else
		{
			txtValue = txtValue.SubString(0, txtValue.IndexOf("#")) + "# " + max.ToString();
		}
		string querytext = "Update LogDatabase set Type = @type where HashKey = @key";
                //Create your SqlParameters here!
		cmd.CommandText = querytext;
		cmd.ExecuteNonQuery();
		SQLiteTrans.Commit();    
		max++; //You weren't increasing your counter!!
	}
    }
