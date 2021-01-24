    using System.Linq;
    // ...
    IEnumerable<string> SwapNumbers(IEnumerable<string> numbers) {
        return numbers.Split(' ').Reverse();
    }
