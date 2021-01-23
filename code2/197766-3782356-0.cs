    public static Member Create(Dictionary<string, object inputs)
    {
        Member oNew = new Member();
        oNew.fName = inputs["fName"].ToString();
        // etc
        return oNew;
    }
