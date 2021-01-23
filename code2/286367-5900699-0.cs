    string sPattern = "^[A-Za-z]+$"
    bool isValid = false;
    while(!isValid)
    {
       Console.WriteLine("Enter Student Name : ");
       string name = Console.ReadLine();
       isValid = System.Text.RegularExpressions.Regex.Match(name, sPattern);
    }
