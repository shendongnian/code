    private enum SearchMode
    {
        TitleOnly,
        TitleAndBody,
        SomeOtherWay
    }
    private SearchMode _selectedSearchMode;
    private void SearchModeRadioButtons_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.Checked)
        {
            if (rb == _radioButtonTitleOnly)
            {
                _selectedSearchMode = SearchMode.TitleOnly;
            }
            else if (rb == _radioButtonTitleAndBody)
            {
                _selectedSearchMode = SearchMode.TitleAndBody;
            }
            else
            {
                // and so on
            }
        }            
    }
