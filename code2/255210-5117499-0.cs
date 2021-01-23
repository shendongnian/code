    List<string> ar = new List<string>();
    
    int charcount = 500;
    int index = 0;
    do
    {
        ar.Add(new string(input.Skip(index).Take(charcount).ToArray()));
        index += charcount;
    } while (index < input.Length);
