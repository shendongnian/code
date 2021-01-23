        [Fact]
        public void Does_not_generate_collisions_within_reasonable_number_of_iterations()
        {
            var ids = new HashSet<string>();
            var minimumAcceptibleIterations = 10000;
            for (int i = 0; i < minimumAcceptibleIterations; i++)
            {
                var result = LUID.Generate();
                Assert.True(!ids.Contains(result), $"Collision on run {i} with ID '{result}'");
                ids.Add(result);
            }            
        }
