    if (skipTextChange)
        skipTextChange = false;
    else
    {
        skipTextChange = true;
        if (PercentageText.Text == "")
        {
            PercentageText.Text = " ";
        }
        if (!PercentageText.Text.EndsWith("%"))
        {
            PercentageText.Text = "" + PercentageText.Text.Trim() + "%";
            PercentageText.SelectionStart = PercentageText.TextLength - 1;
        }
    }
