          var xDocument = file.ToXML();
          var xElementResources = xDocument.Element("resources");
          if (xElementResources != null)
          {
            foreach (XElement element in xElementResources.Descendants("group"))
            {
             string groupName = element.Attribute("name")?.Value;
             if (groupName == "AutoSaveView")
             {
              var labelElements = element.Elements("label");
              foreach (var label in labelElements)
              {
                 switch (label.FirstAttribute.Value)
                 {
                     case "enableAutoSaveCheckEdit1":
                        this.RibbonControlApplicationButtonCaption = label.Value;
						break;
				 }
			  }
		    }
	       }
         }
