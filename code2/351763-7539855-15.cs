    var testA = new TestA();
    var testB = new TestB();
    var testC = new TestC();
    testA.TestB = testB;
    testB.TestCs.Add(testC);
    testC.TestA = testA;
    context.TestAs.Add(testA);
    context.ChangeTracker.DetectChanges();
