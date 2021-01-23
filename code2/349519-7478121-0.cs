    IList<ListItem> dropDownListItems = new List<ListItem>();
    
    foreach (XmlNode node in topicNodes)
    {
       string topicId = node.Attributes["TopicId"].Value;
       string topicName = node.Attributes["TopicName"].Value;
       dropDownList.Add(new ListItem(topicName, topicId)); 
    } 
    
    DropDownList1.DataSource = dropDownListItems 
    DropDownList1.DataBind();
