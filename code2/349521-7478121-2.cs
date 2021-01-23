    IList<ListItem> dropDownListItems = new List<ListItem>();
    
    foreach (XmlNode node in topicNodes)
    {
       string topicId = node.Attributes["TopicId"].Value;
       string topicName = node.Attributes["TopicName"].Value;
       dropDownListItems.Add(new ListItem(topicName, topicId)); 
    } 
    
    DropDownList1.DataSource = dropDownListItems.Distinct(); 
    DropDownList1.DataBind();
