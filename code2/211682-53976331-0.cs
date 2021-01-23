		public class User
		{
			public event EventHandler Changed;	  
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
					this.OnChanged(EventArgs.Empty);
				}
			}
		
			protected virtual void OnChanged(EventArgs e)
			{
				if (Changed != null)
				{
					Changed(this, e);
				}
			}
	   }
	 
