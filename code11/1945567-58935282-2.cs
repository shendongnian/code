    public static void Populate<TL, TR>(IEnumrable<TL> lList, IEnumrable<TR> rList)
    {
        //build a dictionary
        var dictionary = rList.ToDictionary(x => propRightKey.GetValue(r));
        foreach (l in lList)
        {
            //get the value outside of a firstordefault
            var lValue = propLeftKey.GetValue(l);
            //search the value inside the dictionary
            if (dictionary.TryGetValue(lValue, out var foundValue))
                propForeignObj.SetValue(l, foundValue);                
            else
                propForeignObj.SetValue(l, null);
        }
    }
