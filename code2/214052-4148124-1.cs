    using System.Linq
    //other code
    //given that numbers is IEnumerable<double>
    double average = numbers.Average()
    double sum = numbers.Aggregate((tot, n) => tot+n);
    double sumOfSquares = numbers.Select(n => n*n).Aggregate((tot, n) => tot + n);
