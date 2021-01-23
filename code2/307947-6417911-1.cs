    public List<Object> dataList = new List<Object>();
    public  bool AddData(ref Object data)
    bool success = false;
    try
    {
        if (!data.Equals(null))   // I've also used if(data != null) which hasn't worked either
        {
           dataList.Add(data);                      //NullReferenceException occurs here
           success = doOtherStuff(data);
        }
    }
    catch (Exception e)
    {
        throw new Exception(e.ToString());
    }
    return success;
}
