    while (reader.Read())
    {
    	if (reader.ElementType == typeof(SheetData))
    	{
    		if (reader.IsEndElement)
    			continue;
    
    		// Write sheet element
    		writer.WriteStartElement(new SheetData());
    
    		// read first row from template and copy into the new sheet
    		reader.Read();
    		do
    		{
    		  if (reader.IsStartElement)
    			{
    				writer.WriteStartElement(reader);
    				
    				// this bit is needed to get cell values
    				if (reader.ElementType.IsSubclassOf(typeof(OpenXmlLeafTextElement)))
    				{
    					writer.WriteString(reader.GetText());
    				}
    			}
    			else if (reader.IsEndElement)
    			{
    				writer.WriteEndElement();
    			}
    			reader.Read();
    		} while (!(reader.ElementType == typeof(Row) && reader.IsEndElement));
    		writer.WriteEndElement();
    
    		// Write data rows
    		foreach (DataRow dataRow in resultsTable.Rows)
    		{
    			// Write row element
    			Row r = new Row();
    			writer.WriteStartElement(r);
    
    			foreach (DataColumn dataCol in resultsTable.Columns)
    			{
    				Cell c = new Cell();
    				c.DataType = CellValues.String;
    				CellValue v = new CellValue(dataRow[dataCol].ToString());
    				c.Append(v);
    
    				// Write cell element
    				writer.WriteElement(c);
    			}
    
    			// End row
    			writer.WriteEndElement();
    		}
    
    		// End sheet
    		writer.WriteEndElement();
    	}
    	else
    	{
    		if (reader.IsStartElement)
    		{
    			writer.WriteStartElement(reader);
    			// this bit is needed to get formulae and that kind of thing
    			if (reader.ElementType.IsSubclassOf(typeof(OpenXmlLeafTextElement)))
    			{
    				writer.WriteString(reader.GetText());
    			}
    		}
    		else if (reader.IsEndElement)
    		{
    			writer.WriteEndElement();
    		}
    	}
    }
