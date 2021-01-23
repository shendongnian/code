    values.AddRange(from s in _systemData
                    from i in institutionData
                    select s.LookupValue == i.OriginalSystemLookupValue ?
                        new LookupValue {
                            DisplayText = _institutionItem.LookupText,
                            Value = _institutionItem.LookupValue
                        }
                    :   new LookupValue {
                            DisplayText = _systemItem.LookupText,
                            Value = _systemItem.LookupValue
                        }
                   );
