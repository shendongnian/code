    class MyClass
    {
    	public event EventHandler MyEvent;
    	
    	public MyClass()
    	{
    		MyEvent += OnSomeEventHandlerToMyLocalClassWhichOfcourseIsABadPractice;
    	}
    	
    	protected void OnSomeEventHandlerToMyLocalClassWhichOfcourseIsABadPractice(object sender, EventArgs e)
    	{
    		MyEvent -= OnSomeEventHandlerToMyLocalClassWhichOfcourseIsABadPractice;
    	}
    }
