    private void MyFunction(ref MyClass variable)
    {
      variable = new MyClass();
      // You just changed the variable that was passed,
      // even outside the scope of this method!
    }
    
    private void MyFunction(MyClass variable)
    {
      variable = new MyClass();
      // Without ref, the variable is still intact
      // outside of this scope.
    }
