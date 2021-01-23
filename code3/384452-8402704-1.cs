    private void stateInfoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        State selectedState = (State)stateInfoBox.SelectedItem;
        stateTimeZone.Text = selectedState.TimeZone;
        StateCureType.Text = selectedState.CureType;
        stateCureTimeframe.Text = selectedState.CureTimeframe.ToString();
    }
