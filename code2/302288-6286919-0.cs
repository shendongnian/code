    Button[] buttons = ... ;
    for (int i=0; i < buttons.Length; i++)
    {
        Button b = buttons[i];
        b.TabIndex = i;
          ... set other properties here, as desired....
        b.Click += new System.EventHandler(clickHandler[i]);
    }
