    public bool CheckRadioButtons(params RadioButton[] radioButtons)
    {
        foreach (RadioButton radioButton in radioButtons)
        {
            if (radioButton.Checked)
            {
                return true;
            }
        }
        return false;
    }
