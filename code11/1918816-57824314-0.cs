    [MemberData(nameof(Data))]
    public void VerifyGetCarListAsync(int? colorID, List<int> carIDs, int? sellerID){
        // test code
    }
    public static IEnumerable<object[]> Data => {
        yield return new object[] { null, new List<int>{ 42, 2112 }, null };
        yield return new object[] { 1, new List<int>{ 43, 2112 }, null };
        yield return new object[] { null, new List<int>{ 44, 2112 }, 6 };
    }
