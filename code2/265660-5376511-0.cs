    [Dependency]
		public IClientUser  ClientUser
		{
			get
			{
				return _clientUser;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException(
						"value",
						String.Format(Thread.CurrentThread.CurrentUICulture, Properties.Resource.ERR_ARGUMENT_NULL_USERSERVICE)
					);
				_clientUser = value;
			}
		}
