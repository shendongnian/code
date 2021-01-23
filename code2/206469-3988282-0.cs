    using System.Xml.Linq;    // Required for XElement...
    using System.Collections; // Required for Hashtable
    private void InitGridFromXML(string xmlPath)
    {
        var data = XElement.Load(xmlPath);
        // Set Grid data to row nodes (NOTE: grid = DataGrid member)
        var elements = data.Elements("row");
        grid.ItemsSource = elements;
        // Create grid columns from node attributes.  A hashtable ensures
        // only one column per attribute since this iterates through all
        // attributes in all nodes.  This way, the grid can handle nodes with
        // mutually different attribute sets.
        var cols = new Hashtable();
        foreach (var attr in elements.Attributes())
        {
            var col = attr.Name.LocalName;
            // Only add col if it wasn't added before
            if (!cols.Contains(col))
            {
                // Mark col as added
                cols[col] = true;
                // Add a column with the title of the attribute and bind to its
                // value
                grid.Columns.Add(new DataGridTextColumn
                {
                    Header = col,
                    Binding = new Binding("Attribute[" + col + "].Value")
                });
            }
        }
    }
