	private void txtScript_KeyDown(object sender, KeyEventArgs e)
	{
		txtScript.SelectFullLines();
		if (!e.Shift) {
			txtScript.SelectedText = txtScript.SelectedText.ReplaceRegex("^", "\t", System.Text.RegularExpressions.RegexOptions.Multiline);
		} else {
			txtScript.SelectedText = txtScript.SelectedText.ReplaceRegex("^\\t", "", System.Text.RegularExpressions.RegexOptions.Multiline);
		}
	}
