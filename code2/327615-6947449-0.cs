    ToggleButton myToggleButton;
    public override void OnApplyTemplate() {
        base.OnApplyTemplate();
        myToggleButton = GetTemplateChild("toggleButton") as ToggleButton;
        myToggleButton.MouseEnter += new MouseEventHandler(myToggleButton_MouseEnter);
    }
    void myToggleButton_MouseEnter(object sender, MouseEventArgs e) {
            VisualStateManager.GoToState(this, "MouseEnter", true);
        }
