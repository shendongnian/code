    private void B1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        calculateB1B2();
    }
    private void B2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        calculateB1B2();
    }
    private void calculateB1B2()
    {
        if (double.TryParse(B1.Text, out var b1)
            && double.TryParse(B2.Text, out var b2))
        {
            B3.Text = $"{b1 + b2}";
        }
    }
