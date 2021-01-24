        string str = "1214";
        string x;
        string y;
        int digitsCount = str.Count(c => char.IsDigit(c));
        if (digitsCount > 2) {    
            for (int i = 0; i < digitsCount; i++)
            {
                x = str.Substring(i, 1);
                for (int ii = i+ 1; ii < digitsCount ; ii++)
                {
                   y = str.Substring(ii, 1);                      
                   Console.WriteLine(x + " " + y);
                }
            }
        }
