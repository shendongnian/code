	public MethodInfo GetSelectedMethod()
	{
		var index = testListBox.SelectedIndex;
		if (index < 0) return;
		var value = testListBox.SelectedValue;
		return value as MethodInfo;
	}
	private void ThreadProc(object arg)
	{
		var method = (MethodInfo)arg;
		if(method.IsStatic)
			method.Invoke(null, null)
		else
			method.Invoke(this, null);
	}
	private void RunThread()
	{
		var method = GetSelectedMethod();
		if(method == null) return;
		var thread = new Thread(ThreadProc)
		{
			Name = "UIThread",
		};
		thread.Start(method);
	}
