    List<string> accountList = new List<string> {"123872", "987653" , "7625019", "028401"};
    
    int i = accountList.FindIndex(x => x.StartsWith("762"));
    //This will give you index of 7625019 in list that is 2. value of i will become 2.
    //delegate(string ac)
    //{
    //    return ac.StartsWith(a.AccountNumber);
    //}
    //);
           
