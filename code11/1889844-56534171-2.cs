    private void AddEventsToLabel(Label label)
    {
        label.Click -= LabelClick;
        label.MouseEnter -= LabelMouseEnter;
        label.MouseLeave -= LabelMouseLeave;
        label.Click += LabelClick;
        label.MouseEnter += LabelMouseEnter;
        label.MouseLeave += LabelMouseLeave;
    }
    private void LabelClick(object sender, EventArgs e)
    {
        SetColor();
        Label theLabel = (Label)sender;
        clickedLabel = theLabel;
    }
    private void LabelMouseEnter(object sender, EventArgs e)
    {
        Label theLabel = (Label)sender;
        if (theLabel != clickedLabel) theLabel.BackColor = Color.Red;
    }
    private void LabelMouseLeave(object sender, EventArgs e)
    {
        Label theLabel = (Label)sender;
        if (theLabel != clickedLabel) theLabel.BackColor = Color.Yellow;
    }
