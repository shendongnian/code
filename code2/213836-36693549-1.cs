    var objects = new List<Td>();
    for (int i = 0; i < 1000; i++)
    {
        var obj = new Td
        {
            Message = "Hello my friend",
            Code = "Some code that can be put here",
            StartDate = 7652156516,
            EndDate = 365023652035,
            Cts = new List<Ct>(),
            Tes = new List<Te>()
        };
        for (int j = 0; j < 10; j++)
        {
            obj.Cts.Add(new Ct{Foo = i *j});
            obj.Tes.Add(new Te{Bar = i + j});
        }
        objects.Add(obj);
    }
