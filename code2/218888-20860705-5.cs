    int test = 123456782;
    if(test > 100000000 && test < 999999999)
    {
        int check = test % 10;
        string temp = "";
        bool good = false;
        foreach(char c in test.ToString().Substring(0, 8))
        {
     //The character codes for digits follow the same odd/even pattern as the digits.
     //This code puts each digit or its value times 2, into a string and sums the digits
     //after instead of keeping 2 separate totals
            if(c % 2 == 1)
            {
                temp += c;
            }
            else
            {
                temp += (int.Parse(c.ToString()) * 2).ToString();
            }
        }
        int temp2 = temp.Sum((x => int.Parse(x.ToString())));
    //no need to compare the sum to the next 10, the modulus of 10 will work for this
        int temp2mod = temp2 % 10;
        if((temp2mod == 0 && temp2mod == check) || (10 - temp2mod == check))
            good = true;
    }
