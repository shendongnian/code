    private bool LosingFocus = false;
    protected virtual void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (LosingFocus != true)
        {
        base.Text = LeaveOnlyNumbers(Text); 
        }
        LosingFocus = false;
    }
    protected override void OnLostFocus(object sender, RoutedEventArgs e)
    {
        LosingFocus = true;
        string content = Text;
        char[] contents = content.ToCharArray();
        if (content.Length == 8)
        {
            base.Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + Text.Substring(4, 4);
        }
        else if (content.Length == 6)
        {
            int century = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2));
            string tempCentury = content[4].ToString() + content[5].ToString();
            int unknownCentury = Convert.ToInt32(tempCentury);
            if (unknownCentury > century + 1)
            {
                base.Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + "19" + Text.Substring(4, 2);
            }
            else base.Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + "20" + Text.Substring(4, 2);
        }
        else if (content.Length == 4)
        {
            base.Text = Text.Substring(0, 1) + "/" + Text.Substring(1, 1) + "/" + Text.Substring(2, 2);
            int century = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2));
            string tempCentury = content[4].ToString() + content[5].ToString();
            int unknownCentury = Convert.ToInt32(tempCentury);
            if (unknownCentury > century + 1)
            {
                base.Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + "19" + Text.Substring(4, 2);
            }
            else base.Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + "20" + Text.Substring(4, 2);
        }
    }
