		private void comboName_SelectedIndexChanged(object sender, EventArgs e)
		{
			String lookupName = comboName.SelectedText;
			String id = String.Empty;
			Int32 age = 0;
			PullDataFromDatabase(lookupName, ref id, ref age);
			textID.Text = id;
			textAge.Text = age.ToString();
		}
