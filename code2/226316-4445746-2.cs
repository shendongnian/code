    public static double GetSumOfSquares(this IEnumerable<double> numbers)
    {
        if(numbers == null)
           throw new ArgumentNullException("numbers");
        return numbers.Sum(x => x * x);
    }
