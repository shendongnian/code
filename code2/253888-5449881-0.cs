	public class DataTextBox:TextBox
	{
		public DataTextBox()
		{
			this._errorProvider2 = new System.Windows.Forms.ErrorProvider();
			//this.errorProvider1.BlinkRate = 1000;
			this._errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.TextChanged+=new EventHandler(dtb_TextChanged);
			this.Validating += new System.ComponentModel.CancelEventHandler(this.dtb_Validating);
		
		}
		private ErrorProvider _errorProvider2;
		private Boolean _canBeEmpty=true;
		public Boolean canBeEmpty
		{
			get { return (_canBeEmpty); }
			set { _canBeEmpty = value; }
		}
		private void dtb_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ((this.Text.Trim().Length == 0) & !this.canBeEmpty)
			{
				_errorProvider2.SetError(this, "This field cannot be empty.");
				e.Cancel = true;
			}
			else
			{
				_errorProvider2.SetError(this, "");
				e.Cancel = false;
			}
		}
		private void dtb_TextChanged(object sender, EventArgs e)
		{
			if (this.Text.Trim().Length != 0) _errorProvider2.SetError(this, "");
			else _errorProvider2.SetError(this, "This field cannot be empty.");
		}
	}
}
