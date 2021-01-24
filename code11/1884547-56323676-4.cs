    public class Todo
	{
		private string _taskName;
		public string TaskName
		{
			get { return _taskName; }
			set { _taskName = value; }
		}
		private string _description;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		private int _priority;
		public int Priority
		{
			get { return _priority; }
			set { _priority = value; }
		}
	}
