    foreach (string line in lines)
    {
        if (!line.Contains(searchItem))  //<= Notice here I added exclamation mark (!)
        {
            //Do your work when line does not contains search term
        }
        else
        {
            //Do something if line contains search term
        }
    }
