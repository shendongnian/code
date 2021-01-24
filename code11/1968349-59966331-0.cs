static void Main(string[] args)
{
    string destFile = @"E:\folder\numbers.txt";
    List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    using (StreamWriter sw = new StreamWriter(destFile)) {
        for (int i = 0; i < numbers.Count(); i++)
        {
            sw.WriteLine(numbers[i].ToString());
        }
    }
}
The `using` construct takes care of closing the file when the code has finished writing to it and disposing of any "unmanaged resources" that the StreamWriter used.
Instead of the `using` part and the code inside it, you could use a different method which takes an array of strings and writes that out as lines:
File.WriteAllLines(destFile, numbers.Select(n => n.ToString()).ToArray());
