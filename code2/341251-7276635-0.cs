    for (int i = 0; i < myReader.FieldCount; i++)
    {
        string fieldName = myReader.GetName(i);
        if (string.Equals(fieldName , "PrePay", StringComparison.OrdinalIgnoreCase))
        {
            myModel.PrePay = myReader.GetBoolean(i);
            break;
        }
    }
