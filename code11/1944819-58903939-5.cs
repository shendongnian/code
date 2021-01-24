    public void Method1(){ //this method has no parameters
      int x = 5;
      int newX = Method2(x); passes the value of x, to method 2. newX will be set to 10 when Method2 finishes
    }
    public int Method2(int someNumber){ //this method has one, integer, parameter
      return someNumber + 5; //returns 10 back to the calling method, Method1
    }
