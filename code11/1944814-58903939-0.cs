    public void Method1(){ //this method has no parameters
      int x = 5;
      Method2(x); passes the value of x, to method 2
    }
    public void Method2(int someNumber){ //this method has one, integer, parameter
      Console.Out.WritLine(someNumber); //prints out "5", which is the value of x
    }
