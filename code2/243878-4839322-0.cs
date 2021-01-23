    /// declare it in Master Page
    public Dictionary<DateTime, MyObj_Class> MyDic {
          get;
          set;
    }
    /// put the line just under Page directive on your content page where you want to access it
    <%@ MasterType  virtualPath="~/MyMasterPage.master"%>
    /// and then on content page you can access by
    ** Note: The intelisense may not work but don't worry just put the code in content page and it works.**
    Master.MyDic.Add(DateTime.Now, MyObj);
