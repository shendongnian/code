    private readonly Command _ProcessCommandCommand = new Command(p =>
    	{
    		var tb = (TextBox)p;
    		var command = tb.Text;
    		// <Process command>
    		tb.Clear();
    	});
    public Command ProcessCommandCommand { get { return _ProcessCommandCommand; } }
