    XmlNodeList popis = baza.GetElementsByTagName( "element" );
    for ( int i = 0; i < popis.Count; i++ )
    {
    	var element = popis[i];
    	if ( element == null || element.Attributes == null )
    		continue;
    
    	if ( element.Attributes["ID"].Value.ToString() == "0" )
    		continue;
    
    	var idCell = new TableCell { Text = element.Attributes["ID"].Value.ToString() };
    	var imeCell = new TableCell { Text = element.ChildNodes[0].InnerText };
    	var prezimeCell = new TableCell { Text = element.ChildNodes[1].InnerText };
    	var godisteCell = new TableCell { Text = element.ChildNodes[2].InnerText };
    
    	var row = new TableRow();
    	row.Cells.Add( idCell );
    	row.Cells.Add( imeCell );
    	row.Cells.Add( prezimeCell );
    	row.Cells.Add( godisteCell );
    
    	TblPrikaz.Rows.Add( row );
    }
