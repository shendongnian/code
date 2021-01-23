    private void OnClick(object sender, EventArgs args)
    {
        // Do stuff to handle the event.
    }
    
    // This is the form's constructor.
    public MyWinForm()
    {
        InitializeComponents();
    
        this.button1.Click += OnClick;
        this.button2.Click += OnClick;
        this.button3.Click += OnClick;
        this.button4.Click += OnClick;
        this.button5.Click += OnClick;
        this.button6.Click += OnClick;
        this.button7.Click += OnClick;
    }
