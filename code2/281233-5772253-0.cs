    private void SBar_TouchUp(object sender, TouchEventArgs e)
    {
        //siblings.getFirst('textbox').text += 1;
        var siblings = ((sender as FrameworkElement).Parent as Panel).Children;
        var textbox = siblings.OfType<TextBox>().First();
        textbox.Text = (int.Parse(textbox.Text) + 1).ToString();
    }
