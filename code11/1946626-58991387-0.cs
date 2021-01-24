c#
class SizeLimitedList<T> : IEnumerable<T>
{
    private T[] _internalArray;
    private readonly int _capacity;
    
    public SizeLimitedList(int capacity)
    {
        _internalArray = new T[capacity];
        _capacity = capacity;
    }
    public SizeLimitedList(IEnumerable<T> collection)
    {
        _internalArray = collection.ToArray();
        _capacity = _internalArray.Length;
    }
    public void Add(T item)
    {
        MoveArray(1);
        _internalArray[_capacity - 1] = item;
    }
    public T[] GetLastEntries(int n)
    {
        return _internalArray[^n..];
    }
    public T GetLastEntry()
    {
        return _internalArray[^1];
    }
    private void MoveArray(int by)
    {
        var newArray = new T[_internalArray.Length];
        Array.Copy(_internalArray, 1, newArray, 0, _capacity -1);
        _internalArray = newArray;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _internalArray.AsEnumerable().GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
You can use it like so:
c#
var list = new SizeLimitedList<string>(maxLinesKept);
var file = new StreamReader(@"C:\My\Path\To\File.txt");
while((line = file.ReadLine()) != null)
{
    list.Add(line);
    if (/* Condition that requires you to read the last n lines */)
    {
        var lines = list.GetLastEntries(nLinesToGet);
        // Do whatever with these last lines
    }
}
This is a little complicated, so let me make an example. Let's say you want to print a line to the console, but only when the previous line contains "Print Next Line:"
txt
Print Next Line:
Hello
This line will not be printed
Print Next Line:
World
So now let's implement it:
c#
var list = new SizeLimitedList<string>(1);
var file = new StreamReader("example.txt");
while((line = file.ReadLine()) != null)
{
    if (list.GetLastEntry() == "Print Next Line:")
        Console.WriteLine(line);
    list.Add(line);
}
This will print:
Hello
World
Into the console
P.S Feel free to leave a comment or update your original question with a sample of your file and the condition of when to read the last n lines and I can update my example to match your use-case
