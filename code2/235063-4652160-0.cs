    private XElement FillSubCatagories(XElement cat) {
            IEnumerable<XElement> list = cat.Descendants();
            int catTypeID = c.Attribute("CatTypeID") == null ? 1 : Int32.Parse(cat.Attribute("CatTypeID").Value);
            foreach (XElement c in list) {
            if(!String.IsNullOrEmpty(cat.Attribute("CatID").Value))
            {
                int parentID = Int32.Parse(cat.Attribute("CatID").Value);
                XElement sub = new XElement("sub",
                    from s in db.Categories
                    where s.CatTypeID.Equals(catTypeID) && s.ParentID.Equals(parentID)
                    select new XElement("Category",
                         s.CatID == null ? null : new XAttribute("CatID", s.CatID),
                         s.ParentID == null ? null : new XAttribute("ParentID", s.ParentID),
                         s.CatTitle == null ? null : new XAttribute("CatTitle", s.CatTitle),
                         s.CatTypeID == null ? null : new XAttribute("CatTypeID", s.CatTypeID),
                         s.shortDesc == null ? null : new XAttribute("shortDesc", s.shortDesc),
                         s.longDesc == null ? null : new XAttribute("longDesc", s.longDesc),
                         s.CatImage == null ? null : new XAttribute("CatImage", s.CatImage)));
                c.Add(sub);
                FillSubCatagories(c);
                }
            }
            return cat;
        }
