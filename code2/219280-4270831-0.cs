    public ParentControl()
    {
        CustomUserControl tempControl = new CustomUserControl();
        this.Controls.Add(tempControl);
        tempControl.Click += new Event(localClickEvent);
    }
