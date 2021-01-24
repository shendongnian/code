    string newNameTemp = " [i]";
    while (newNameTemp.StartsWith(" ")) {
        newNameTemp = newNameTemp.Remove(0,1);
        Console.WriteLine("1");
    }
    if (newNameTemp.StartsWith("[i]")) {
        newNameTemp.Remove(0,3);
        Console.WriteLine("2");
    }
