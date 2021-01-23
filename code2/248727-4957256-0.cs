		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			VerifyPropertyName(propertyName);
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		protected void OnPropertyChanged(object sender, string propertyName)
		{
			PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
		}
		public void VerifyPropertyName(string propertyName)
		{
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				throw new Exception("Invalid property name: " + propertyName);
			}
		}
	
