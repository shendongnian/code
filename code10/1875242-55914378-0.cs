C#
static int SumOf(List<int> nums)
{
    nums = nums ?? throw new ArgumentNullException(nameof(nums)); // C# 7 syntax for check the nums is null
    int total = 0;
    foreach(var item in nums)
    {
        total += item;
    }
    return toal;
}
Or
C#
static int SumOf(List<int> nums)
{
    nums = nums ?? throw new ArgumentNullException(nameof(nums)); // C# 7 syntax for check the nums is null
    int total = 0;
    nums.ForEach(item=>total += item;)
    return toal;
}
or **use the `Linq` extension method**
C#
using System.Linq;
static int SumOf(List<int> nums)
{
    nums = nums ?? throw new ArgumentNullException(nameof(nums)); // C# 7 syntax for check the nums is null
    return nums.Sum()
}
