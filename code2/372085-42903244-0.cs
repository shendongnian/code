        private void PleaseSelectValueLabel_Click(object sender, EventArgs e)
        {
            PleaseSelectValueLabel.SendToBack();
            AssessmentValue.Focus();
        }
        private void AssessmentValue_Click(object sender, EventArgs e)
        {
            PleaseSelectValueLabel.SendToBack();
        }
        //if the user hasnt selected an item, make the please select label visible again
        private void AssessmentValue_Leave(object sender, EventArgs e)
        {
            if (AssessmentValue.SelectedIndex < 0)
            {
                PleaseSelectValueLabel.BringToFront();
            }
        }
