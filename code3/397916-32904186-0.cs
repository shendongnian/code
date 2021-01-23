     public bool ValidateRadioButtonList()
    {
        bool rbchecked= false;
        for (int i = 0; i < RadioButtonList1.Items.Count - 1; i++)
        {
            if (RadioButtonList1.Items[i].Selected==true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            lblError.Text = string.Empty;
            return true;
        }
        else
        {
            lblError.Text = "Please select RadioButton!";
            return false;
        }
    }
