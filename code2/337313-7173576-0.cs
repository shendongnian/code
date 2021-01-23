     [Test]
     //[ExpectedException()]
     public void CheckLists_FailsAt0()
     {
        var expected = new[] { 0.0001, 0.4353245, 1.3455234, 345345.098098 };
        var result1 = new[] { -0.0004, 0.43520, 1.3454, 345345.0980 };
        Assert.That(result1, Is.EqualTo(expected).AsCollection.Within(0.0001), "fail at [0]"); // fail on [0]    
        }
    [Test]
    //[ExpectedException()]
    public void CheckLists_FailAt1()
    {
        var expected = new[] { 0.0001, 0.4353245, 1.3455234, 345345.098098 };
        var result1a = new[] {  0.0001000000 , 0.4348245000 , 1.3450234000 , 345345.0975980000  };                      
        Assert.That(result1a, Is.EqualTo(expected).AsCollection.Within(0.0001), "fail at [1]"); // fail on [3]        
        }
    [Test]    
    public void CheckLists_AllPass_ForNegativeDiff_of_1over10001()
    {
        var expected = new[] { 0.0001, 0.4353245, 1.3455234, 345345.098098 };
        var result2 = new[] {  0.00009900 , 0.43532350 , 1.34552240 , 345345.09809700 };
        Assert.That(result2, Is.EqualTo(expected).AsCollection.Within(0.0001)); // pass      
     }
     [Test]
     public void CheckLists_StillPass_ForPositiveDiff_of_1over10001()
     {
        var expected = new[] { 0.0001, 0.4353245, 1.3455234, 345345.098098 };
        var result3 = new[] {  0.00010100 ,  0.43532550  , 1.34552440 , 345345.09809900 };
        Assert.That(result3, Is.EqualTo(expected).AsCollection.Within(0.0001)); // pass
     }
