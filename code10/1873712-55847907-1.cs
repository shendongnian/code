    public void Button_Click(object sender, EventArgs e)
    {
        Style style = new Style { TargetType = typeof(Button) };
        style.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Green));
        Resources["MyButtonStyle"] = style;
    }
