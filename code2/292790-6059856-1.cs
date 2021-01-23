    int x = 0;
    string s = "IAmAString-00001";
    foreach (char c in s.Reverse())//Use Reverse() so you start with digits only.
    {
        if(char.IsDigit(c) == false)
            break;//If we start hitting non-digit characters, then exit the loop.
        ++x;
    }
    int num = int.Parse(s.Substring(s.Length - x, x));
    Console.WriteLine("Your Number is: {0}", num);
