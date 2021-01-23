    public void AddEx(this TabCollection tabs, string name)
    {
      var myTabPage = MyFindTabPageMethod(name);
      tabs.Add(myTabPage);    
    }
