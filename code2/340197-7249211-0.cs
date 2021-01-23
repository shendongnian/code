    foreach(string pair in input.Split(new Char [] {','}))
    {
       string [] items = pair.Split(new Char [] {':'});
       Console.WriteLine(items[0]);
       Console.WriteLine(items[1]);
    }
