    var set = new HashSet<int>();  //a set cannot have duplicate elements
    for (var i = 0; i < vektor.Length; i++)
    {
        var number = int.Parse(Console.ReadLine());
        if (!set.Add(number))
        {
            //value already exists on the set
        }
    }
