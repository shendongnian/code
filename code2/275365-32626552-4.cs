	void Main()
	{
		var test=new employee();
		test.PropertyChanged += HandleSomethingHappening;
		test.hire_date = DateTime.Now;
	}
	
	public void HandleSomethingHappening(object sender, EventArgs e)
	{
		var propName=((System.ComponentModel.PropertyChangedEventArgs)e).PropertyName;
		var empObj=(employee)sender;
		if (propName=="hire_date")
		{
			Console.WriteLine(propName+" changed to: " + empObj.hire_date.Date.ToString("d"));
		}
	}
