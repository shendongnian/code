        public static IEnumerable<object[]> TestGetPersonItemsData =>
            new List<object[]>
            {
                new object[] { 0, 10, new List<string> { "DEV", "IT" }, "", 3 }
            };
        [Theory]
        [MemberData(nameof(TestGetPersonItemsData))]
        public async Task TestGetPersonItems(int pageNumber, int pageSize, List<string> departments, string filterText, int resultCount)
        {
            // Test
        }
