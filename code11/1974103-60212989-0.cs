    public IDictionary<int, string> IndexKeyPairs
    {
    	get
    	{
    		if (_keys == null)
    		{
    			_keys = new Dictionary<int, string>();
    			if (_headerRow != null)
    				foreach (Worksheet.Cell cell in _headerRow.Cells)
    					_keys.Add(new KeyValuePair<int, string>(cell.Address.Column, GetValue(cell)));
    		}
    		return _keys;
    	}
    }
