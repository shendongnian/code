    public bool GetAllElementsByAttributeValue(XElement startingNode, Relationship findAmong, string attName, string attValue, out IEnumerable<XElement> matchingNodes, out string msg)
    {
        bool ret = true;
        msg = "SUCCESS";
        matchingNodes = null;
        try
        {
            switch (findAmong)
            {
                case Relationship.Descendants:
                    matchingNodes = from items in startingNode.Descendants()
                                    where items.Attribute(attName) != null && items.Attribute(attName).Value == attValue
                                    select items;
                    break;
                case Relationship.Ancestors:
                    matchingNodes = from items in startingNode.Ancestors()
                                    where items.Attribute(attName) != null && items.Attribute(attName).Value == attValue
                                    select items;
                    break;
                case Relationship.Siblings:
                    matchingNodes = from items in startingNode.Parent.Descendants()
                                    where items.Attribute(attName) != null && items.Attribute(attName).Value == attValue
                                    select items;
                    break;
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
            ret = false;
        }
        return ret;
    }
