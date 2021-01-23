    AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
    allowedTypes.AddRange(yourArrayOfSuggestions);
    txtType.AutoCompleteCustomSource = allowedTypes;
    txtType.AutoCompleteMode = AutoCompleteMode.Suggest;
    txtType.AutoCompleteSource = AutoCompleteSource.CustomSource;
