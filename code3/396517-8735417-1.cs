    str = fileRead.ReadLine();
    int testNum;
    
    if (Int32.TryParse(str, out testnum))
    {
        // however, I'm not sure how you're using iter here; if it's related to 
        // parsing the string, you'll probably need to do something else
        level.ChangeTile(i, iter, num);
    }
