class TransformationOne
{
    private int _currentResult;
    public int Calculate(int value)
    {
        _currentResult += value;
        return _currentResult;
    }
}
so you could do:
var transformationOne = new TransformationOne();
var inputs = new List<int> {1, 2, 1, 0, 3, 2};
foreach (var input in inputs)
{
    var newResult = transformationOne.Calculate(input); 
    Console.WriteLine(newResult); // results: 1 3 4 4 7 9
}
[Demo](https://dotnetfiddle.net/Qdkmj3)
