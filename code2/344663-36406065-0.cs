    using DevExpress.XtraBars.Alerter;
    
    // Create a regular custom button.
    AlertButton btn1 = new AlertButton(Image.FromFile(@"c:\folder-16x16.png"));
    btn1.Hint = "Open file";
    btn1.Name = "buttonOpen";
    // Create a check custom button.
    AlertButton btn2 = new AlertButton(Image.FromFile(@"c:\clock-16x16.png"));
    btn2.Style = AlertButtonStyle.CheckButton;
    btn2.Down = true;
    btn2.Hint = "Alert On";
    btn2.Name = "buttonAlert";
    // Add buttons to the AlertControl and subscribe to the events to process button clicks
    alertControl1.Buttons.Add(btn1);
    alertControl1.Buttons.Add(btn2);
    alertControl1.ButtonClick += new AlertButtonClickEventHandler(alertControl1_ButtonClick);
    alertControl1.ButtonDownChanged += 
        new AlertButtonDownChangedEventHandler(alertControl1_ButtonDownChanged);
    
    // Show a sample alert window.
    AlertInfo info = new AlertInfo("New Window", "Text");
    alertControl1.Show(this, info);
    
    void alertControl1_ButtonDownChanged(object sender, 
    AlertButtonDownChangedEventArgs e) {
        if (e.ButtonName == "buttonOpen") {
            //...
        }
    }
    
    void alertControl1_ButtonClick(object sender, AlertButtonClickEventArgs e) {
        if (e.ButtonName == "buttonAlert") {
            //...
        }
    }
