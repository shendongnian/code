		#region Table Dump Implementation
	    private static XNode Dump<T>(IEnumerable<T> items, IEnumerable<string> header, params Func<T, string>[] columns)
        {
            if (!items.Any())
                return null;
                
			var html = items.Aggregate(new XElement("table", new XAttribute("border", 1)),
				(table, item) => { 
					table.Add(columns.Aggregate(new XElement("tr"),
						(row, cell) => { 
							row.Add(new XElement("td", EvalColumn(cell, item)));
							return row; 
						} ));
					return table;
				});
			
			html.AddFirst(header.Aggregate(new XElement("tr"),
				(row, caption) => { row.Add(new XElement("th", caption)); return row; }));
				
	        return html;
        }
	    private static XNode EvalColumn<T>(Func<T, string> cell, T item)
	    {
	        var raw = cell(item);
	        try
	        {
	            var xml = XElement.Parse(raw);
	            return xml;
	        }
	        catch (XmlException)
	        {
	            return new XText(raw);
	        }
	    }
	    #endregion
	    #region Dot Diagrams
	    public void LinkDiagram(Digraph graph, string id)
	    {
            if (!graph.AllNodes.Any())
                return;
	        var img = Path.GetFileName(GenDiagramFile(graph, _directory, id));
	        _body.Add(
                new XElement("a",
                    new XAttribute("href", img),
                    new XElement("h4", "Link naar: " + graph.name),
                            new XElement("img",
                                new XAttribute("border", 1),
                                new XAttribute("src", img),
                                new XAttribute("width", "40%"))));
	    }
