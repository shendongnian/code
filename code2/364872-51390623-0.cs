    private void CopyFormPropertiesAndValues()
    {
        MergeOperationsContext context = new MergeOperationsContext() { GroupRoot = _groupRoot, FormMerged = MergedItem };
        // set up filter functions caller
        var CheckFilters = (string key, string value) =>
        {
            foreach (var FieldFilter in MergeOperationsFieldFilters)
            {
                if (!FieldFilter(key, value, context))
                    return false;
            }
            return true;
        };
        // Copy values from form to FormMerged 
        foreach (var key in _form.ValueList.Keys)
        {
            var MyValue = _form.ValueList(key);
            if (CheckFilters(key, MyValue))
                MergedItem.ValueList(key) = MyValue;
        }
    }
