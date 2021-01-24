    const int rodLength = 50;
    const int lengthA = 8, lengthB = 10, lengthC = 12;
    var solver = SolverContext.GetContext();
    var model = solver.CreateModel();
    var decisionA = new Decision(Domain.IntegerNonnegative, "A");
    model.AddDecision(decisionA);
    var decisionB = new Decision(Domain.IntegerNonnegative, "B");
    model.AddDecision(decisionB);
    var decisionC = new Decision(Domain.IntegerNonnegative, "C");
    model.AddDecision(decisionC);
    model.AddGoal("Goal", GoalKind.Minimize,
        rodLength - (decisionA * lengthA) - (decisionB * lengthB) - (decisionC * lengthC));
    const int maxItems = 20;
    model.AddConstraint("MaxItems", decisionA + decisionB + decisionC < maxItems);
    var solution = solver.Solve();
    Console.WriteLine("A " + decisionA.GetDouble());
    Console.WriteLine("B " + decisionB.GetDouble());
    Console.WriteLine("C " + decisionC.GetDouble());
