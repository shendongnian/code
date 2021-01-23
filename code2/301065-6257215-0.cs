    case XmlNodeType.Element:
        elementName = reader.Name;
        elementText = null;                  // ADDED
        switch (elementName)
        {
            //display my title stuff
        }
        break;
...
    case XmlNodeType.EndElement:
        if (elementName == reader.Name && elementText != null)       // MODIFIED
        {
            contractRowArray1[0] = elementName;
            contractRowArray1[1] = elementText;
            contractRow = contractTable.NewRow();
            contractRow.ItemArray = contractRowArray1;
            contractTable.Rows.Add(contractRow);
        }
        break;
