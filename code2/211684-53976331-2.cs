		public class User
		{
			public event EventHandler AgeChanged;	  
			private string _UserName;
			public string UserName
			{
				get
				{
					return _UserName;
				}
				 set  
				{
					_UserName = value;
					this.OnAgeChanged(this,EventArgs.Empty);
				}
			}
		
			protected virtual void OnAgeChanged(object sender, EventArgs e)
			{
				if (AgeChanged != null)
				{
					AgeChanged(sender, e);
				}
			}
	   }
	 
