    public int GetOrdinal(string fieldName) { // V1.2.3300
    	if (null == fieldName) {
    		throw ADP.ArgumentNull("fieldName");
    	}
    	int index = IndexOf(fieldName);
    	if (-1 == index) {
    		throw ADP.IndexOutOfRange(fieldName);
    	}
    	return index;
    }
    public int IndexOf(string fieldName) { // V1.2.3300
    	if (null == _fieldNameLookup) {
    		GenerateLookup();
    	}
    	int index;
    	object value = _fieldNameLookup[fieldName];
    	if (null != value) {
    		// via case sensitive search, first match with lowest ordinal matches
    		index = (int) value;
    	}
    	else {
    		// via case insensitive search, first match with lowest ordinal matches
    		index = LinearIndexOf(fieldName, CompareOptions.IgnoreCase);
    		if (-1 == index) {
    			// do the slow search now (kana, width insensitive comparison)
    			index = LinearIndexOf(fieldName, ADP.compareOptions);
    		}
    	}
    	return index;
    }
