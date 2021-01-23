        private RadioButton GetSelectedRadioButton(params RadioButton[] radioButtonGroup)
        {
            // Go through all the RadioButton controls that you passed to the method
            for (int i = 0; i < radioButtonGroup.Length; i++)
            {
                // If the current RadioButton control is checked,
                if (radioButtonGroup[i].Checked)
                {
                    // return it
                    return radioButtonGroup[i];
                }
            }
            // If none of the RadioButton controls is checked, return NULL
            return null;
        }
