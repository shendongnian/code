    List<int> numericList = new List<int>(new int[] { 1, 3, 2, 3, 4, 3 });
    List<string> stringList = numericList.ConvertAll<string>(x => x.ToString());
    
    if (String.Join(",", l2.ToArray()).Contains("1,3,2,3"))
    {
        //get sequence
    }
