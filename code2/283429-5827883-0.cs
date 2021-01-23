    IEnumerable<int> sequenceOfInts = new int[] { 1, 2, 3 };
    IEnumerable<Foo> sequenceOfFoos = new Foo[] { new Foo() { Bar = "A" }, new Foo() { Bar = "B" } };
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string outputOfInts = serializer.Serialize(sequenceOfInts);
    string outputOfFoos = serializer.Serialize(sequenceOfFoos);
