    //Try to parse your captured data to Integer
    try
    {
        // remmeber, textboxes always capture the data as a string therefore we need to convert to an integer
        CourseDetails.Name = Convert.ToInt32(txtName.Text);
        CourseDetails.SCNnumber = Convert.ToInt32(txtSCNnumber.Text);
        if(CourseDetails.Name.ToString() == "" && CourseDetails.SCNnumber.ToString() == "")
        {
         MessageBox.Show("Please complete all fields");
        }
    }
    //If the parse fails, then throw an exception
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
