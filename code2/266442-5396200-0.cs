    foreach(ListItem li in interestedCheckBoxList.Items)
    {
       //add your stuff
       if(li.Selected)
       {
           //should be using string builder here but....
           message.Body += "<p>Interested In: " + li.Text + "</p>";
       }
    }
