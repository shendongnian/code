    public class RadioGroup
    {
        List<RadioButton> _radioButtons;
        public RadioGroup(params RadioButton[] radioButtons)
        {
            _radioButtons = new List<RadioButton>(radioButtons);
            foreach (RadioButton radioButton in _radioButtons)
            {
                radioButton.TabStop = false;
                radioButton.KeyUp += new KeyEventHandler(radioButton_KeyUp);
                radioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            }
            _radioButtons[0].TabStop = true;
        }
        void radioButton_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            RadioButton radioButton = (RadioButton)sender;
            int index = _radioButtons.IndexOf(radioButton);
            if (e.KeyCode == Keys.Down)
            {
                index++;
                if (index >= _radioButtons.Count)
                {
                    index = 0;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                index--;
                if (index < 0)
                {
                    index = _radioButtons.Count - 1;
                }
                e.Handled = true;
            }
            radioButton = _radioButtons[index];
            radioButton.Focus();
            radioButton.Select();
        }
        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton currentRadioButton = (RadioButton)sender;
            if (currentRadioButton.Checked)
            {
                foreach (RadioButton radioButton in _radioButtons)
                {
                    if (!radioButton.Equals(currentRadioButton))
                    {
                        radioButton.Checked = false;
                    }
                }
            }
        }
    }
