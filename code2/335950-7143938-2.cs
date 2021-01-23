    class YourClass
	{
		private void saveButton_Click(object sender, EventArgs e)
		{
				saveFile1.DefaultExt = "*.txt";
				saveFile1.Filter = ".txt Files|*.txt|All Files (*.*)|*.*";
				saveFile1.RestoreDirectory = true;
				if (saveFile1.ShowDialog() == DialogResult.OK)
				{
					StreamWriter sw = new StreamWriter(saveFile1.FileName);
					List<string> theList = new List<string>();
					foreach (var line in theFinalDGV.Rows)
					{
						string linecontent = line.RowToString();
						if (linecontent.Contains("FUJI"))
							richTextBox1.AppendText(linecontent + "\n");
					}
				}
		}
	}
	
	public static class Extender {
		public static string RowToString(this DataGridViewRow dgvr) {
			string output = "";
			DataGridView dgv = dgvr.DataGridView;
			foreach (DataGridViewCell cell in dgvr.Cells) {
				DataGridViewColumn col = cell.OwningColumn;
				output += col.HeaderText + ":" + cell.Value.ToString() + ((dgv.Columns.IndexOf(col) < dgv.Columns.Count - 1) ? ", " : "");
			}
			return output;
		}
	}
