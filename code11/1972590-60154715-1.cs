    private void Button1_Clicked(object sender, EventArgs e)
    {
        var changeWidthAnimation = Button1.Width == 150
            ? new Animation(b => Button1.WidthRequest = b, 150, 40)
            : new Animation(b => Button1.WidthRequest = b, 40, 150);
    
        changeWidthAnimation.Commit(this, nameof(changeWidthAnimation), 16, 150, Easing.Linear);
    }
