    string xml = @"<Query>
    <Where>
    <Eq>
    <FieldRef Name=""ID"" />
    <Value Type=""Title"">
     1 
    </Value>
    </Eq>
    </Where>
    </Query>";
    var el = XElement.Parse(xml);
    var value = el.Descendants("Value").FirstOrDefault();
    value.Attribute("Type").Value = "abcdef";
    value.Value = "ghijkl";
    string newXml = el.ToString();
