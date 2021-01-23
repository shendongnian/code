    List<ObjectParameter> objectParameterList = new List<ObjectParameter>();
    if (string.IsNullOrEmpty(param1))
    {
        object nullValue = DBNull.Value;
        objectParameterList.Add(new ObjectParameter("param1", nullValue));
    }
    else
    {
        objectParameterList.Add(new ObjectParameter("param1", param1));
    }
    context.ExecuteFunction("MyEFModel.sp", objectParameterList.ToArray());
