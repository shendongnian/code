	static class DataGridViewExtension
	{
		public static void AddCustomRow(this DataGridView dgv, object [] values, object tag = null)
		{
			int Index = dgv.Rows.Add(values);
			// Add a tag if one has been specified
			if (tag != null)
			{
				DataGridViewRow row = dgv.Rows[Index];
				row.Tag = tag;
			}
		}
		public static void AddCustomRow(this DataGridView dgv, string text, object tag = null)
		{
			AddCustomRow(dgv, new object[] { text }, tag);
		}
	}
