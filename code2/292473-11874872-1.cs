    Dictionary<string, string> dic = new Dictionary<string, string>();
    // dictionary other items already added.
    MethodThatReturnAnotherDic(dic);
    
    public void MethodThatReturnAnotherDic(Dictionary<string, string> dic)
    {
        dic.Add(.., ..);
    }
