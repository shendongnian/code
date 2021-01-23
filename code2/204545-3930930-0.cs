    interface test
    {
         test bind();
         test  DoSomethingElse();
    }
    
    class tester:test
    {
        test bind()
        { 
             // blah 
        }
    
        test DoSomethingElse()
        { 
             // blah 
        }
    }
    
    tester obj = new tester()
    obj.bind().DoSomethingElse()
