    XDocument doc = XDocument.Load(yourXMLString);
    var rows = doc.Descendants("QuestId").Select(el => new()
        {
          Answer1 = el.Element("Answer1").Value,
          Answer2 = el.Element("Answer2").Value,
          Answer3 = el.Element("Answer3").Value,
          Answer4 = el.Element("Answer4").Value,
        });
    // iterate over the rows and add to DataTable ...
