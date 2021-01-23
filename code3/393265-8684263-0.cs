    [MyRole(Name = new[] { "Security.Action" })]
    void BlockAccount(string accountId){}
    [MyRole(Name = new[] { "Manager.Action" })]
    void CreateAccount(string userName){}
    [MyRole(Name = new[] { "Security.View", "Manager.View" })]
    List<> AcountList(Predicate p){}
