    public void DeleteRows(IElement table)
    {
        var rows = table?.QuerySelectorAll("tr").ToArray();
        foreach (var row in rows)
        {
    	    row.Remove();
        }
        var legnthAfterDeletion = table?.QuerySelectorAll("tr")?.Length;
    }
