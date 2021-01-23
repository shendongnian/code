	void Main()
	{
		var test=new employee();
		test.PropertyChanged += HandleSomethingHappening;
		test.hire_date = DateTime.Now;
	}
	
	public void HandleSomethingHappening(object sender, EventArgs e)
	{
		Console.WriteLine("Hire date changed to: " 
				+ ((employee)sender).hire_date.Date.ToString("d"));
	}
