    class Program
    {
        static void Main()
        {
            var nums1 = new int[] { 2, 4, 6, 8, 10, 9 };
            var nums2 = new int[] { 1, 3, 6, 9, 12, 2 };
    
            if (nums1.Intersect(nums2).Any()) // check if there is equal items
            {
                var equalItems = nums1.Intersect(nums2); // get list of equal items (2, 6, 9)
    
                // ...
            }
        }
    }
