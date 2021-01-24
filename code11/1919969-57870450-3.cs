        public static IEnumerable<object[]> TestSearchPersonItemsData =>
            new List<object[]>
            {
                new object[] { new SearchDTO { searchText = "", page = 0, pageSize = 10 }, 3 },
                new object[] { new SearchDTO { searchText = "test", page = 1, pageSize = 10 }, 1 }
            };
        [Theory]
        [MemberData(nameof(TestSearchPersonItemsData))]
        public async Task TestSearchPersonItems(SearchDTO searchDTO, int resultCount)
        {
            // Test
        }
