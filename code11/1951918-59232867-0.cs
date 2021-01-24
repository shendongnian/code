    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var output = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            foreach (var outie in output)
            {
                Console.WriteLine($"{outie[0]}, {outie[1]}, {outie[2]}");
            }
    
            Console.Read();
    
        }
        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            var lookup = new List<int>(nums);
            var returnList = new List<IList<int>>();
    
            for (var i = 0; i < nums.Length; i++)
            {
                var result = TwoSum(i, lookup);
                if (result != null)
                {
                    var fullResult = new List<int> { nums[i], nums[result[0]], nums[result[1]] };
                    fullResult.Sort();
                    if (!returnList.Any(b => b.SequenceEqual(fullResult)))
                    {
                        returnList.Add(fullResult);
                    }
                }
            }
            return returnList;
        }
    
        private static int[] TwoSum(int thirdnumIndex, List<int> nums)
        {
            var target = nums[thirdnumIndex];
    
            for (var i = 0; i < nums.Count; i++)
            {
                var comp = (target + nums[i]) * -1;
                if (nums.Contains(comp))
                {
                    var indexOfComp = nums.IndexOf(comp);
                    if (indexOfComp == i || indexOfComp == thirdnumIndex)
                    {
                        return null;
                    }
    
                    return new[] { i, indexOfComp };
                }
    
            }
            return null;
        }
    }
