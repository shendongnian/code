    public class RegexMaskedTextBox : TextBox
    {
	   private Regex _regex = new Regex(string.Empty);
	   public string RegexPattern
	   {
		get { return _regex.ToString(); }
		set { _regex = new Regex(value); }
	   }
	   protected override void OnKeyPress(KeyPressEventArgs e)
	   {
		string sNewText = this.Text;
		string sTextToInsert = e.KeyChar.ToString();
		if (this.SelectionLength > 0)
		{
			sNewText = this.Text.Remove(this.SelectionStart, this.SelectionLength);
		}
		sNewText = sNewText.Insert(this.SelectionStart, sTextToInsert);
		if (sNewText.Length > this.MaxLength)
		{
			sNewText = sNewText.Substring(0, this.MaxLength);
		}
		e.Handled = !_regex.IsMatch(sNewText);
		base.OnKeyPress(e);
	   }
    }
