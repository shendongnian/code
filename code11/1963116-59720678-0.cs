    int userid;
    List<Character> chars = BusinessLayer.Instance.ChooseChar(userid);
    foreach(var character in JoinLists)
    {
        if (character._number == userid)
        Console.WriteLine(character._type);
    }
