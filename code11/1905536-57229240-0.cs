     private void ValidateInputOfControls(Control.ControlCollection[] controlsArray)
        {          
            foreach (Control.ControlCollection controlCollection in controlsArray)
            {
                foreach (Control control in controlCollection)
                {
                    if (control is TextBox)
                    {
                        int result;
                        if (int.TryParse(control.Text, out result))
                        {
                            if (!(result >= 0 && result <= 100))
                            {
                                MessageBox.Show("Please enter a number from 1 - 100 in field " + control.Name);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a number from 1 - 100 in field " + control.Name);
                        }
                     }
                }               
            }
        }
