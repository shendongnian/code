    Test1 test1variable = _context.Test1.SingleOrDefault(n => n.Id == 1);
    Test2 test = _context.Test2.SingleOrDefault(n => n.Id == 4);
    Test1_Test2 test1_2 = new Test1_Test2 {  Test1 = test1variable, Test2 = test };
    test1variable.Test1_Test2.Add(test1_2);
    _context.SaveChanges();
            
