    public static IEnumerable<long> SortToMiddle (long[] nums) {
        // Array.Sort(nums) // Optionally uncomment line to ensure sorted array.
        if (nums != null && nums.Length != 0) {
            // Move forward every two.
            for (int i = 0;  i < nums.Length;  i+=2)
                yield return nums[i];
            // Move backward every other two. Note: Length%2 makes sure we're on the correct offset.
            for (int i = nums.Length-1 - nums.Length%2;  i >= 0;  i-=2)
                yield return nums[i];
    	}
    }
