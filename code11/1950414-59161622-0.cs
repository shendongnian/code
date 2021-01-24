    var properties = new Dictionary<string, string>();
    properties.Add("Prop1", "Value");
    var members = new Dictionary<string, Dictionary<string, string>>();
    members.Add("Member1", properties);
    var group = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
    group.Add("GroupName", members);
