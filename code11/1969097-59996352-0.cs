    string[] lines = File.ReadAllLines(@"c:\temp\values.txt");
    int sum = 0;
    foreach(string line in lines)
      sum = sum + int.Parse(line);
    Console.WriteLine("sum is " + sum);
