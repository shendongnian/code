	public void AsyncExecute(int parameter, EventHandler completed)
	{
		...
	}
	
	
	//in your code
	
	AsyncExecute(1, delegate (object sender, EventArgs e) { code for case 1... });
	AsyncExecute(2, delegate (object sender, EventArgs e) { code for case 2... });
