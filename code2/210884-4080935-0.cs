    var coll = new NameValueCollection();
    coll.Add("Z", "1");
    coll.Add("A", "2");
    coll.Add("Z", "3");
    Console.WriteLine(coll[0]); // prints "1,3"
