    [WebMethod]
    public static County[] GetCounties(int Stateid)
    {
        County[] countiesArr = StatesCountyModel.GetCountyForState(Stateid).ToArray();
        return countiesArr;     
    }
