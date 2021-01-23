    //...
    ToolTip ttip = new ToolTip();
    for (int i = 0; i < 7; i++) {
        for (int j = 0; j < 4; j++) {
            Button btn = new Button();
            // ...
            ttip.SetToolTip(btn, "Some text on my tooltip.");
        }
    }
    //...
