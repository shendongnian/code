    public string StripAfterLastNumber(string s)
    {
           int index= s.LastIndexOfAny("0123456789".ToCharArray());
           return s.Remove(index+1);
    }   
