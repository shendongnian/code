    private void AddEventsToAllLabels()
    {
        AddEventsToChildLabels(this);
    }
    private void AddEventsToChildLabels(Control parent)
    {
        if (parent is Label)
        {
            AddEventsToLabel(parent as Label);
        }
        else
        {
            foreach (Control control in parent.Controls)
            {
                AddEventsToChildLabels(control);
            }
        }
    }
    private void AddEventsToLabel(Label label)
    {
        label.Click += (sender, e) => {
            SetColor();
            Label theLabel = (Label)sender;
            clickedLabel = theLabel;
        };
        label.MouseEnter += (sender, e) =>
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel) theLabel.BackColor = Color.Red;
        };
        label.MouseLeave += (sender, e) =>
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel) theLabel.BackColor = Color.Yellow;
        };
    }
