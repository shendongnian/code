    Button button = CreateButton("Save", "save", (s, e) => SomeOnClickEvent(s, e));
	Button button2 = CreateButton("Create", "create", (s, e) => SomeOtherOnClickEvent(s, e));
	
	public Button CreateButton(string display, string name, Action<object, EventArgs> click)
	{
		Button b = new Button()
		{
			Content = display,
			Name = $"Btn_{name}"
		};
		
		b.Click += new EventHandler(click);
		
		return b;
	}
	
	void SomeOnClickEvent(object sender, EventArgs e)
	{
		
	}
	
	void SomeOtherOnClickEvent(object sender, EventArgs e)
	{
		
	}
