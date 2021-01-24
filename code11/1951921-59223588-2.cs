    Branch b = new Branch() { BranchStatus = 3 };
    User u = new User() { UserStatus = 1 };
    Console.WriteLine(b.GetStatusFieldName()); // prints BranchStatus
    Console.WriteLine(u.GetStatusFieldName()); // prints UserStatus
    Console.WriteLine(b.GetStatus()); // prints 3
    Console.WriteLine(u.GetStatus()); // prints 1
