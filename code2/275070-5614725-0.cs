        public Person Manager 
		{
			get
			{
 				return (_manager );
			}
			set
			{
				if (_manager != null)
				{
					_manager.WorkPlace = null;
				}
				_manager = value;
				if (_manager != null)
				{
					_manager.WorkPlace = this;
				}
			}
