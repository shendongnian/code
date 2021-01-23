    bool OneLuckyGuy(Person p1, Person p2, Person p3, Person p4)
    {
         return OneAndOnlyOneIsTrue(new [] {         
             p1.IsAMan(),
             p2.IsAMan(),
             p3.IsAMan(),
             p4.IsAMan()
         });
    }
    
