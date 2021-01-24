    var testContext = new TestContext();
    var classA = new ClassA
    {
        Name = "classAName"
    };
    testContext.ClassAs.Add(classA); // <--
    var classB = new ClassB
    {
        Action = "create",
        ClassA = new ClassAOwned
        {
            ClassAId = classA.ClassAId, // <--
            Name = classA.Name
        }
    };
    testContext.ClassBs.Add(classB);
    classB.ClassA.ClassAId = classA.ClassAId;
    testContext.SaveChanges();
