    Boolean addSeperator = false;
    foreach (ListItem li in interestedIN.Items)
    {
        if (addSeperator)
        {
            interestIN += ", ";
            addSeperator = false;
        }
        if (li.Selected)
        {
            interestIN += li.Text;
            addSeperator = true;
        }
    }
    
