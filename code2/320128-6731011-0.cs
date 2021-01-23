     int[] nums = new[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7 };
     IEnumerable<int> top5 = nums
                .GroupBy(i => i)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key);
