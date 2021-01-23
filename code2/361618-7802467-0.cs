    private void EvilMethod1() {  
        x = (int) Math.Pow((double) y, 2); 
    } 
    private void EvilMethod2() {  
        y = (x + y) * 2; 
    }
    private void DoWorkWithBoth()
    {
        y = EvilMethod1();  // side effects on x while assigning y
        x = EvilMethod2();  // side effects on y while assigning x
        // What are their expressions now?
        if(x == expectedValue1 || y == expectedValue2)
        { /* ...*/ }
    }
