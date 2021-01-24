    string input = "aSd2&5s@1";
    char[] inputArray = input.ToCharArray();
    string output = "";
    
    string ab = "";
    foreach (char c in inputArray)
    {
        int x;
        string y;
        if(int.TryParse(c.ToString(), out x))
        {
            string sb = "";
            ab = ab.ToUpper();
            for(int i=0;i<b;i++)
            {
               sb += ab;
            }
            ab = "";
            output += sb;
        }
        else
        {
            ab += c;
        }
    }
    if(!string.IsNullOrEmpty(ab))
    {
        output += ab.ToUpper();
    }
    Console.WriteLine(output);
