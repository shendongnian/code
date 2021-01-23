    public class SelectedValueValidator
	{
		public const string UNSPECIFIED_DATATYPE = "11";
		private string selectedValue = "11";
		public string SelectedValue
		{
			get { return selectedValue; }
			set { selectedValue = value; }
		}
		public bool IsValid()
		{
			return (SelectedValue != UNSPECIFIED_DATATYPE);
		}
	}
