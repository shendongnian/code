    foreach (object value in dic.Values)
    {
        Dictionary<object, object> nestedDic = (Dictionary<object, object>)value;
        foreach (object nestedValue in nestedDic.Values)
        {
            MessageBox.Show(nestedValue.ToString());
        }
    }
