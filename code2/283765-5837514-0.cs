    this.ButtonSignOn.MouseEnter += this.ChangeOtherButton;
    this.ButtonSingOn.MouseLeave += this.RevertOtherButtonChanges;
    
    // later on
    private void ChangeOtherButton(object sender, EventArgs e)
    {
        this.OtherButton.ForeColor = Colors.Red;
        this.OtherButton.BackColor = Color.Blue;
        // more styling ...
    }
    // mostly same stuff when reverting changes
    
