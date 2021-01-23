            XDocument doc = XDocument.Load(XMLDataSourceUtil.GetXMLFilePath(locale, "Navigation.xml"));
            var targetNode = doc.Descendants().Where(p => p.Value == "h3").FirstOrDefault();
            string path = null;
            List<string> lst = new List<string>();
            if (targetNode != null)
            {
                lst.AddRange(targetNode.AncestorsAndSelf().Elements("LinkText").Select(p => p.Value).ToList<string>());//.Aggregate((i, j) => j + ">>" + i);
                lst.AddRange(targetNode.AncestorsAndSelf().Elements("LinkURL").Select(p => p.Value)); 
                lst.Reverse();
            }
            rptBreadCrumb.DataSource = lst;
            rptBreadCrumb.DataBind();    
