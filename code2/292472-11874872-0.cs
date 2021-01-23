    Dictionary<string, string> dic = new Dictionary<string, string>();
    MethodThatReturnAnotherDic(dic);
    
    public void MethodThatReturnAnotherDic(Dictionary<string, string> dic)
    {
        dic.Add(.., ..);
    }
