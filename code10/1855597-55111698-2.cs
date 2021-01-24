    oks = ks;
    ks = KeyBoard.GetState();
    Keys[] pressed = new Keys[0];
    if(ks != oks)
    {
       // A key was pressed
       pressed = ks.GetPressedKeys();
    }
    foreach(var key in pressed)
       Console.WriteLine(key.ToString());
