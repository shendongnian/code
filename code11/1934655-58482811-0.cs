    var data1 = testList.GroupBy(e => e.TestProp1).Select(g=> new AClass
    {
        prop = g.Key,
        // this line here! Note the cast
        bClass = g.GroupBy(p=> p.TestProp2).Select(g1 => (BClass)(new CClass {
            prop1 = g1.FirstOrDefault().TestProp1,
            prop2 = g1.FirstOrDefault().TestProp2,
            prop3 = ... // why don't you also set prop3?
            
        })).ToList()
    }).ToList();
