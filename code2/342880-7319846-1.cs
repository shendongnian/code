    UserControl2 userControl2 = (UserControl2)FindControl(this, "UserControl2");
    userControl2.UserControl2Event += new UserControl2Delegate(userControl2_UserControl2Event);
    ...
    void userControl2_UserControl2Event(object sender, EventArgs e)
    {
        //Do something        
    }
    ...
    private Control FindControl(Control parent, string id)
    {
        foreach (Control child in parent.Controls)
        {
            string childId = string.Empty;
            if (child.ID != null)
            {
                childId = child.ID;
            }
            if (childId.ToLower() == id.ToLower())
            {
                return child;
            }
            else
            {
                if (child.HasControls())
                {
                    Control response = FindControl(child, id);
                    if (response != null)
                        return response;
                }
            }
        }
        return null;
    }
