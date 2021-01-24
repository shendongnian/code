    public static void Populate<TL, TR>(IEnumrable<TL> lList, IEnumrable<TR> rList)
    {
        //build a lookup
        var lookUp = rList.ToLookup(x => propRightKey.GetValue(r));
        foreach (l in lList)
        {
            //get the value outside of a firstordefault
            var lValue = propLeftKey.GetValue(l);
            //search the value inside the lookup and get the FirstOrDefault entry
            var foundValue = lookUp[lValue].FirstOrDefault();
            propForeignObj.SetValue(l, foundValue);
        }
    }
