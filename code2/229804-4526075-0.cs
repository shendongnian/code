		private static int CompareTabIndex(TextBox c1, TextBox c2)
		{
			return c1.TabIndex.CompareTo(c2.TabIndex);
		}
		public static bool IsValid(Form form)
		{
			List<TextBox> textBoxes = new List<TextBox>();
			foreach(Control ctl in form.Controls)
			{
				TextBox textBox = ctl as TextBox;
				if(textBox != null) textBoxes.Add(textBox);
			}
			textBoxes.Sort(new Comparison<TextBox>(CompareTabIndex));
			foreach(TextBox textBox in textBoxes)
			{
				if(textBox.AccessibleDescription == "Valid" && textBox.Text.Trim() == "")
				{
					MessageBox.Show(textBox.AccessibleName + " Can't be Blank",
						Program.companyName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					textBox.Focus();
					return false;
				}
			}
			return true;
		}
