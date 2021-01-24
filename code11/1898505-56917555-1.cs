    var obj1 = new
    {
        ID = 1,
        Title = "text",
        Test = new Test()
        {
            Number = 20,
            IsSomething = false
        }
    };
    var obj2 = new
    {
        Age = 22
    };
    dynamic obj3 = obj1.Merge(obj2);
    Console.WriteLine(obj1.ID.Equals(obj3.ID)); // True
    Console.WriteLine(obj1.Title.Equals(obj3.Title)); // True
    Console.WriteLine(obj1.Test.Equals(obj3.Test)); // True
    Console.WriteLine(obj2.Age.Equals(obj3.Age)); // True
