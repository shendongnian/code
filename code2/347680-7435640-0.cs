    static void Main(string[] args)
        {
            int[] allNumbers = Enumerable.Range(1, 20).ToArray();
            GetNumbers(ref allNumbers, new int[] { 16, 17 });
        }
        private static void GetNumbers(ref int[] nums, int[]exclude)
        {
            List<int> numsToExlucde =new List<int>();
            numsToExlucde.InsertRange(0, exclude);
            nums = nums.Where(w => !numsToExlucde.Contains(w)).ToArray();
        }
