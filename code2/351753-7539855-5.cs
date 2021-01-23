    var testA = new TestA();
    var testB = new TestB();
    var testC = new TestC();
    context.TestAs.Add(testA);
    testA.TestB = testB;
    testB.TestCs.Add(testC);
    testC.TestA = testA;
    context.ChangeTracker.DetectChanges();
