       [TestMethod]
    public void CodedUITestMethod1()
    {
        this.UIMap.RedPathCodeParams.UITextBox1EditText="1";
        this.UIMap.RedAndGreenPath();
        this.UIMap.RedPathCodeParams.UITextBox1EditText="2"
        this.UIMap.RedAndGreenPath();
    }
     public void RedAndGreenPaths()
    {
        #region Variable Declarations
        WinEdit uITextBox1Edit = this.UIForm1Window.UITextBox1Window.UITextBox1Edit;
        WinButton uIButton1Button = this.UIForm1Window.UIButton1Window.UIButton1Button;
        WinButton uIAbortButton = this.UIErrorWindow.UIAbortWindow.UIAbortButton;
        WinButton uIButton2Button = this.UIForm1Window.UIButton2Window.UIButton2Button;
        #endregion
        // Type '2' in 'textBox1' text box
        uITextBox1Edit.Text = this.RedPathCodeParams.UITextBox1EditText;
        // Click 'button1' button
        Mouse.Click(uIButton1Button, new Point(35, 10));
        // Click '&Abort' button
        if(this.RedPathCodeParams.UITextBox1EditText=="2") //You could also use uIAbortButton.Exists instead
        Mouse.Click(uIAbortButton, new Point(51, 12));
        // Click 'button2' button
        Mouse.Click(uIButton2Button, new Point(56, 16));
    }
