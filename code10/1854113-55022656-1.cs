c#
[Fact]
public void SimpleLambdaTest()
{
    int[] nums = Enumerable.Range(1, 10).ToArray();
    nums.Should().OnlyContain(num => EqualsOne(num));
}
private static bool EqualsOne(int num)
{
    // You can put a break point here
    return num == 1;
}
