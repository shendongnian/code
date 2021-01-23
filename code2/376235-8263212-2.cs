    public void ProcessDataField(DataField field)
    {
    	var stringField = field as IValue<string>;
    	if (stringField != null) {
    		string s = stringField.Value;
    	}
    }
