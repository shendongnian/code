    private DeviceStatus _Status;
		public DeviceStatus Status
		{
			get { return _Status; }
			set
			{
				this.Set(ref _Status, value);
				RaisePropertyChanged(nameof(this.StatusVisibility));
			}
		}
		public Visibility StatusVisibility
		{
			get
			{
				switch (_Status)
				{
					case DeviceStatus.Busy: //add other statuses here
						return Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
		}
