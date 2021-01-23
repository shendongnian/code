    string s = "IAmAString-00001";
    int num = 0;
    int iChars = 0;//Keep track of what Base power to use.
    foreach (char c in s.Reverse())//Use Reverse() so you start with digits only.
    {
        if(char.IsDigit(c) == false)
            break;//If we start hitting non-digit characters, then exit the loop.
        //Subtract ASCII char '0' to get the numeric representation of the character.
        num += (c - '0') * (int)(Math.Pow(10, iChars));
        //As we work backwards increase each digit by it's base power.
        ++iChars;
    }
    Console.WriteLine("Your Number is: {0}", num);
