    string[] lines = File.ReadAllLines(@"C:\MyDictionary.txt");
    HashSet<string> myDictionary = new HashSet<string>();
    foreach (string line in lines)
    {
      myDictionary.Add(line);
    }
    string word = "aadvark";
    if (myDictionary.Contains(word))
    {
      Console.WriteLine("There is an aadvark");
    }
    else
    {
      Console.WriteLine("The aadvark is a lie");
    }
