	public class A 
	{
		public A()
		{
			this.B = new B();
		}
		public B B
		{
			get; private set;
		}
	}
	public class B : Freezable, INotifyPropertyChanged
	{
		protected override Freezable CreateInstanceCore()
		{
			return new B();
		}
		private string _c = "initial string";
		public string C
		{
			get
			{
				return _c;
			}
			set
			{
				this._c = value;
				this.OnPropertyChanged("C");
				this.OnChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			var safe = this.PropertyChanged;
			if (safe != null)
			{
				safe(this, new PropertyChangedEventArgs(name));
			}
		}
	}
