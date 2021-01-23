        private bool ValidateForm()
                {
                    int val1, direction = 0;
                    double speed = 0.0;
        
                    bool validated;
                    if (txtName.Text != "")
                    {
                        try
                        {
                            //attempts to convert values into their primary data types. Any errors will throw an exception that will be reported as invalid data
                            int counter = 1;
                            val1 = Convert.ToInt32(txtXPos.Text);
                            counter = counter + 1;
                            val1 = Convert.ToInt32(txtYPos.Text);
                            counter = counter + 1;
                            speed = Convert.ToDouble(txtSpeed.Text);
                            counter = counter + 1;
                            direction = Convert.ToInt32(txtDirection.Text);
                            validated = true;
                        }
                        catch
                        {
                        switch(counter)
    
                          case 1:
     
                         txtXPos.Text="";
                          break;
                          case 2:
     
                          txtYPos.Text="";
                            break;
                          case 3:
    
                         txtSpeed.Text="";
                         break;
                         case 4:
    
                         txtDirection.Text="";
                          break;
                         default:
                         break;
                            MessageBox.Show("You have an invalid value entered. Please check your entry.", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            validated = false;
                        }
                        if (speed < 0.0 || speed > (double)newAirplane.PlanePosition.MaxSpeed)
                        {
                            MessageBox.Show("Speed entered is out of range.", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            validated = false;
                        }
                        if (direction < 0 || direction > 359)
                            MessageBox.Show("Direction is out of range", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a name.", "Blank Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        validated = false;
                    }
        
        
        
                    return validated;
        
                }
