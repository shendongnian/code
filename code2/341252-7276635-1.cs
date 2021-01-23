    for (int i = 0; i < myReader.FieldCount; i++)
    {
        string name = myReader.GetName(i);
        if (string.Equals(name , "PrePay", StringComparison.OrdinalIgnoreCase))
        {
            object value = myReader.GetValue(i);
            if (!Convert.IsDBNull(value))
            {
                myModel.PrePay = (bool)value;
            }
            break;
        }
    }
