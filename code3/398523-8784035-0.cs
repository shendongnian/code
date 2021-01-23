     XDocument doc = XDocument.Load(file);
     //List from ClaimHomePage 
     var ClaimHomePage = from ele in doc.Root.Element("ClaimHomePage").Descendants("item")
                                select new
                                {
                                     ControlID=(string)ele.Element("controlID"),
                                     rolesEnabled = (string)ele.Element("rolesEnabled"),
                                     rolesVisible = (string)ele.Element("rolesVisible"),
                                };
      var ClaimBillDetailHC= from ele in doc.Root.Element("ClaimBillDetailHC").Descendants("item")
                                select new
                                {
                                     ControlID=(string)ele.Element("controlID"),
                                     rolesEnabled = (string)ele.Element("rolesEnabled"),
                                     rolesVisible = (string)ele.Element("rolesVisible"),
                                };
