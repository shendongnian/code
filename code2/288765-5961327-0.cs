    protected void topicDropDownMenu_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string[] chosenItem;
        chosenItem = null;
        ubTopicDropDownList.Items.Clear();
    
        chosenItem = topic[topicDropDownMenu.SelectedItem.Value];
    
        foreach (string item in chosenItem)
        {
            SubTopicDropDownList.Items.Add(item);
        }
    
    }
