	public class TimeRange : IDataErrorInfo
	{
		public DateTime Start { get; set; }
		public DateTime Finish { get; set; }
		
		#region IDataErrorInfo Members
		public string Error
		{
			get { throw new NotImplementedException(); }
		}
		private bool _IsValid()
		{
			return Finish > Start;
		}
		public string this[string columnName]
		{
			get
			{
                string result = null;
                if (columnName == "Start" && !_IsValid())
                    result = "Start must occure before Finish!";
                else if (columnName == "Finish" && !_IsValid())
                    result = "Finish must occure after Start!";
				return result;
			}
		}
		#endregion
	}
