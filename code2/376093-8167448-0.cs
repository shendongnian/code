	class FormattedTextModel
	{
		private string _raw;
			
		public event EventHandler TextChanged;
			
		public string RawText
		{
			set
			{
				_raw = value;
				EventHandler tmp = TextChanged;
				if (tmp != null) tmp(this, EventArgs.Empty);
			}
			get { return _raw; }
		}
		
		public string RTFText
		{
			return <Convert to rtf here>
		}
	}
