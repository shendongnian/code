    int i;
    
    if(!int.TryParse(txtBoxPatientID.Text, out i))
        {
        return; //or message the user to enter a valid input.
    }
    // Get Patient ID from app
    c.patientID = i;
    bool success = c.Delete(c);
    if (success == true)
    {
        // Successfully Deleted
        MessageBox.Show(" Operation reussite");
        // refresh data grid
        //Load Data on Data GridView
        DataTable dt = c.Select();
        dgvContactList.DataSource = dt;
        // Call the clear method
        Clear();
    }
    else
    {
        // failed to deleted
        MessageBox.Show(" Operation echouée");
    }
