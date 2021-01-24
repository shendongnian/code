    override public int GetOrdinal(string name) {
    	SqlStatistics statistics = null;
    	try {
    		statistics = SqlStatistics.StartTimer(Statistics);
    		if (null == _fieldNameLookup) {
    			CheckMetaDataIsReady();
    			_fieldNameLookup = new FieldNameLookup(this, _defaultLCID);
    		}
    		return _fieldNameLookup.GetOrdinal(name); // MDAC 71470
    	}
    	finally {
    		SqlStatistics.StopTimer(statistics);
    	}
    }
