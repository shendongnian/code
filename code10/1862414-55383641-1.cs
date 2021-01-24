    //Try to parse your captured data to Integer
    try
    {
     
        if(txtName.Text == "" && txtSCNnumber.Text == "")
        {
         MessageBox.Show("Please complete all fields");
        }
        else
        {
        // remmeber, textboxes always capture the data as a string therefore we need to convert to an integer
         CourseDetails.Name = Convert.ToInt32(txtName.Text);
         CourseDetails.SCNnumber = Convert.ToInt32(txtSCNnumber.Text);
        }
    }
    //If the parse fails, then throw an exception
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
