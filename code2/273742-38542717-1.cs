    public enum typFoo : int
    {
       itemA = 1,
       itemB = 2,
       itemC = 3
    }
    
    var mydic = EnumHelper.ConvertToDictionary<typFoo>();
