    private void ClearControls()
		{
			foreach (TextBox x in Controls.OfType<TextBox>())
			{
				x.Clear();
			}
			foreach (DataGridView x in Controls.OfType<DataGridView>())
			{
				x.Columns.Clear();
			}
		}
