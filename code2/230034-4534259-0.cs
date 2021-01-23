        public static string Format(this DataGridViewRow row, string separator)
		{
			string[] values = new string[row.Cells.Count];
			for (int i = 0; i < row.Cells.Count; i++)
				values[i] = row.Cells[i].Value + "";
			return string.Join(separator, values);
		}
