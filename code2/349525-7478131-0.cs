    Dictionary<string, DropDownListClass> topics = new Dictionary<string, DropDownListClass>(); 
    
    foreach (XmlNode node in topicNodes)
    {
       string topicId = node.Attributes["TopicId"].Value;
       string topicName = node.Attributes["TopicName"].Value;
       topics[topicName] = new DropDownListClass { Id = topicId, Name = topicName }; 
    } 
    
    DropDownList1.DataSource = topics.Values;
    DropDownList1.DataBind();
