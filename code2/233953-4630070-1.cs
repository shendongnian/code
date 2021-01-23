    private List<RadioButton> _radioButtonGroup = new List<RadioButton>();
    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.Checked)
        {
            foreach(RadioButton other in _radioButtonGroup)
            {
                if (other == rb)
                {
                    continue;
                }
                other.Checked = false;
            }
        }
    }
