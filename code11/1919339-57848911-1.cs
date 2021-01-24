    public void TestFullAdder()
    {
       FullAdder adder = new FullAdder();
    
       //Test1
       bool result = adder.GetSum(true,true,false);
       Assert.AreEqual(false, result);
    
       result = adder.GetCarry(true,true,false);
       Assert.AreEqual(true, result);
    
       ///  do these for the whole truth table and the unit tests will be ready.
    }
