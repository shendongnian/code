	public class Class_RetrieveCommand : INotifyPropertyChanged
	{
		private bool _cRCmd;
		private bool _cSCmd;
		private string _cmd;
		private bool _sCmd;
		public string CMD
		{
			get { return _cmd; }
			set
			{
				_cmd = value;
				InvokePropertyChanged(new PropertyChangedEventArgs("CMD"));
			}
		}
		public bool C_R_CMD
		{
			get { return _cRCmd; }
			set
			{
				_cRCmd = value;
				InvokePropertyChanged(new PropertyChangedEventArgs("C_R_CMD"));
			}
		}
		public bool S_CMD
		{
			get { return _sCmd; }
			set
			{
				_sCmd = value;
				InvokePropertyChanged(new PropertyChangedEventArgs("S_CMD"));
			}
		}
		public bool C_S_CMD
		{
			get { return _cSCmd; }
			set
			{
				_cSCmd = value;
				InvokePropertyChanged(new PropertyChangedEventArgs("C_S_CMD"));
			}
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		public void InvokePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}
	}
