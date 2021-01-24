      public static Tuple<int, int> FindTwoSum(int[] nums, int target) {
        Dictionary<int, int> hashData = new Dictionary<int, int>();
        for (int index = 0; index < nums.Length; index++)
        {
            int remainingTarget = target - nums[index];
            if (hashData.ContainsKey(remainingTarget))
            {
                return new new Tuple<int, int>(hashData[remainingTarget], index);
            }
            else
            {
                if (!hashData.ContainsKey(nums[index]))
                {
                    hashData.Add(nums[index], index);
                }
            }
        }
        
        return null;
    }
