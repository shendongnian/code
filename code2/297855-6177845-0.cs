    PropertyInfo[] props = new PropertyInfo[]
    {
      typeof(ResultObject).GetProperty("prop1"),
      typeof(ResultObject).GetProperty("prop2"),
    };
    for (int i = 0; i < props.Length; i++)
    {
      props[i].SetValue(result, fieldValue, null);
    }
