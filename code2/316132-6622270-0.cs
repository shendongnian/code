    public IEnumerable<SubChild> GetSubChilds(XmlDocument xd)
    {
       foreach (XmlNode subChild in xd.SelectNodes("/root/*/*"))
       {
           if (subChild.Name.StartsWith("sub_child"))
           {
               XmlAttributeCollection atts = subChild.Attributes;
               yield return new SubChild { a1 = atts["attr1"].Value, a2 = atts["attr2"].Value };
           }
       }
    }
