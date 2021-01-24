        public static IEnumerable<object[]> TestSearchPersonItemsData =>
            new List<object[]>
            {
                new object[] { new SearchDTO { SearchText = "", Page = 0, PageSize = 10 }, 3 }
            };
        [Theory]
        [MemberData(nameof(TestSearchPersonItemsData))]
        public async Task TestSearchPersonItems(SearchDTO searchDTO, int resultCount)
        {
            // Test
        }
