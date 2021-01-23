    for (int i = 0; i < Reader.FieldCount; i++)
    {
        thisrow +=  Reader.GetValue(i).ToString();
        urlname = Reader.GetValue(i).ToString();
    
        urls[i] =  Reader.GetValue(i).ToString();
    }
