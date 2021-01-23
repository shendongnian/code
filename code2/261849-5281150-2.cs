    string line = GetLine();
    var fields = line.Split(',');
    // somehow get the identifier
    string id = GetIdentifier();
    ItemDesc desc;
    if (!ItemLookup.TryGetValue(id, out desc))
    {
        // unrecognized identifier
    }
    else
    {
        int fieldNo = 3; // or whatever field is after the identifier
        foreach (var c in desc.Fields)
        {
            switch (c)
            {
                case 'i' :
                   // try to parse an int and save it.
                   break;
                case 's' :
                   // save the string
                   break;
                default:
                   // error, unknown field type
                   break;
             }
             ++fieldNo;
        }
    }
    // at this point if no errors occurred, then you have a collection
    // of parsed fields that you saved.  You can now create your object.
