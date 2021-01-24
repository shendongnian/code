    public string getRadioButtonIdByGroupName(string groupName)
    {
        //loop all controls on the page
        foreach (var control in (Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls)
        {
            //check if the control is a radiobutton
            if (control is RadioButton)
            {
                //cast the control to a radiobutton
                var radioButton = control as RadioButton;
                //check if it is the correct group name and if it's checked
                if (radioButton.GroupName == groupName && radioButton.Checked)
                {
                    //return the value
                    return radioButton.ID;
                }
            }
        }
        return "NotFound";
    }
