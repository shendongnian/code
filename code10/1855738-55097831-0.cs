    string str = "Hi, my name is Satpreet Singh\nI'm a .NET Developer";
    str = new string((from c in str
                      where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                      select c
    ).ToArray());
    string[] splitted = str.Split(new char[0]);
    Console.WriteLine(splitted.Length);
    Console.ReadLine();
