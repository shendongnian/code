    static void Main(string[] args)
    {
        int[] left = { 1, 0 };
        int[] right = { 5 };
        int[] actual = Sum(left, right);
        int[] expected = { 1, 5 };
        bool ok = actual.SequenceEqual(expected); // true
    }
    static int[] Sum(int[] left, int[] right)
    {
        var length = Math.Max(left.Length, right.Length);
        left = Pad(left, length);
        right = Pad(right, length);
        var max = length - 1;
        bool carry = false;
        var stack = new Stack<int>(left.Zip(right, (Left, Right) => new { Left, Right })
            .Reverse()
            .Select((i, index) =>
            {
                var res = i.Left + i.Right;
                if (carry)
                    res++;
                carry = res > 9 && index < max;
                if(carry)
                    res %= 10;
                return res;
            }));
        var last = stack.Pop();
        return stack.Concat(new[]
                            {
                                last % 10,
                                last / 10 // remove this line to prevent array expanding
                            })
                    .Reverse()
                    .SkipWhile(i => i == 0) // remove this line to prevent array shrinking
                    .ToArray();
    }
    static int[] Pad(int[] array, int length) =>
        new string(array.Select(i => i.ToString().First()).ToArray())
            .PadLeft(length, '0')
            .Select(c => int.Parse(c.ToString()))
            .ToArray();
