    protected void YourDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YourDropDownList.SelectedValue == "Training")
            {
                int numberRequested = getNumberRequested(); //implement it accordingly
                if (numberRequested < 16)
                {
                    //send error message
                }
            }
        }
