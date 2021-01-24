        [Fact]
        public void Test()
        {
            var selectClauseExecutionCount = 0;
            var original = Enumerable.Range(1, 100);
            var enumerated = original.Select(a =>
            {
                selectClauseExecutionCount++; ;
                return a;
            });
            var concated = enumerated.Concat(new[] { 1, 2, 3 });
            Assert.Equal(0, selectClauseExecutionCount);
            var appended = concated.Append(5);
            Assert.Equal(0, selectClauseExecutionCount);
            Assert.Equal(5, appended.Last());
            Assert.Equal(100, selectClauseExecutionCount);
        }
