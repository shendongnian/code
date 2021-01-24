    object[] list = new object[]
    {
        new object(),
        1,
        "ciao",
        new object[] { 1, 2, 3, 4, 5 },
        "pizza",
        new object[] { "ciao", "pizza" },
        new List<object>(){ 123, 456 }
    };
    foreach (ICollection collection in list.OfType<ICollection>())
    {
        //Here you can work with every collection found in your list
    }
