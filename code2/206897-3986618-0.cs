    foreach (var kvp in personalizePatientChartDictionaryOriginal)
    {
        int value;
        if (personalizePatientChartDictionary.TryGetValue(kvp.Key, out value))
        {
            if (kvp.Value != value)
            {
                hasDictionaryChanged = true;
                break;
            }
        }
    }
