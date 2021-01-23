    str = fileRead.ReadLine();
    string[] values = str.Split(new Char[] {' '});
    foreach (string value in values)
    {
        int testNum;
    
        if (Int32.TryParse(str, out testnum))
        {
            // again, not sure how you're using iter here
            level.ChangeTile(i, iter, num);
        }
    }
