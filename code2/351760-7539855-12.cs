    var testA = context.TestAs.Find(1); // assuming there is already one in the DB
    var testB = new TestB();
    var testC = new TestC();
    testA.TestB = testB;
    testB.TestCs.Add(testC);
    testC.TestA = testA;
    context.SaveChanges(); // or DetectChanges, it doesn't matter
