	public class Solution
	{
		public int[] TwoSum(int[] nums, int target)
		{
			int[] ret = new int[2]; 
			
			if (nums.Length < 2)
				return ret;
				
			int start = 0;
			int end = 1;
			while (start < (nums.Length -1))
			{			
				if (nums[start] + nums[end] == target)
				{
					ret[0] = start; 
					ret[1] = end;
					break; 
				}
				
				if (end < nums.Length -1))
				{
					end++
				}
				else
				{
					start++;
					end = start + 1
				}
			}
			
			return ret; 
		}
	}
