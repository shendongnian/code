    string schxml = field.SchemaXml;
    // If it contains the "Format=" parameter, change the format from Dropdown to RadioButtons.
    // Otherwise, insert the Format= option into the XML string
    if (schxml.Contains("Format="))
    {
        schxml = schxml.Replace("Dropdown", "RadioButtons");
    }
    else
    {
        schxml = schxml.Replace("Choice\"", "Choice\" Format=\"RadioButtons\"");
    }
    
    // Update the XML string in the field definition
    field.SchemaXml = schxml;
    
    // Update the field
    field.Update();
