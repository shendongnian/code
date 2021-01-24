    static IEnumerable<int> SkipEvery(int[] numbers, int skip)
    {
    	for (int i = 1; i <= numbers.Length; i++)
    	{
    		if ((i % (skip + 1)) != 0)
    			yield return numbers[i - 1];
    		else
    			yield return -1;
    	}
    }
    static void Main(string[] args)
    {
    	int[] numbers = new int[] { 7, 2, 24, 69, 101, 42, 84, 100, 72 };
    	string result = string.Join("\t", SkipEvery(numbers, 3).Select((x, i) => $"[{i}]{x}"));
        Console.WriteLine(result);
    }
