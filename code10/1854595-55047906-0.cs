    Button button1 = new Button() {...}
    Button button2 = new Button() {...}
    button1.OnClicked += this.OnButtonClicked;
    button2.OnClicked += this.OnButtonClicked;
    // both buttons will call OnButtonClicked when pressed
