    public static IEnumerable<object[]> SearchData() {
        yield return new object[] { new SearchDTO { searchText = "", page = 0, pageSize = 10 }, 3 };
        yield return new object[] { new SearchDTO { searchText = "", page = 0, pageSize = 5 }, 6 };
    }
    [Theory]
    [MemberData(nameof(SearchData))]
    public async Task TestSearchPersonItems(SearchDTO searchDTO, int resultCount) {
        //...
    }
