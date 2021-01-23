	public string Blah
	{
		get
		{
			if (InvokeRequired)
				return (string) Invoke(new Func<string>(() => Blah));
			else
				return Text;
		}
		set
		{
			if (InvokeRequired)
				Invoke(new Action(() => { Blah = value; }));
			else
				Text = value;
		}
	}
